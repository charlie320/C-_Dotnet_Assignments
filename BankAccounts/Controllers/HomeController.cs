using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BankAccounts.Models;
using DbConnection;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {

        private BankAccountContext _context;

        public HomeController(BankAccountContext context) {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index() {
            HttpContext.Session.Clear();
            Console.WriteLine(HttpContext.Session);
            ViewBag.InitSession = HttpContext.Session;
            return View("Index");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult LoginPage() {
            HttpContext.Session.Clear();
            ViewBag.InitSession = HttpContext.Session;
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        // public IActionResult Login(string Email, string Password) {
        public IActionResult Login(User LoginUser) {
            
            User RetrievedUser = _context.Users.SingleOrDefault(user => user.Email == LoginUser.Email);
            if (RetrievedUser != null && LoginUser.Password != null) {
                var Hasher = new PasswordHasher<User>();
                if (0 != Hasher.VerifyHashedPassword(RetrievedUser, RetrievedUser.Password, LoginUser.Password)) {
                    HttpContext.Session.SetInt32("CurrentUserId", RetrievedUser.UserId);
                    return RedirectToAction("Account");
                }
            }
            ViewBag.error = "Login information is invalid.";
            return View("Login");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model) {
            
            if(ModelState.IsValid) {
                User user = new User {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    AccountBalance = 0.0,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, model.Password);

                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            // *****One way to extract validation errors*****
            // foreach (var modelState in ModelState.Values) {
            //     foreach (ModelError error in modelState.Errors) {
            //         Console.WriteLine(error.ErrorMessage);
            //     }
            // }

            // *****Another way to extract validation errors.  However, Web app will utilize @Http.ValidationSummary() on client side to display errors*****
            // IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            // ViewBag.errors = allErrors;

            return View("Index");
        }

        [HttpGet]
        [Route("account")]
        public IActionResult Account() {
            if (HttpContext.Session.GetInt32("CurrentUserId") != null) {
                User RetrievedUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrentUserId"));
                ViewBag.RetrievedUser = RetrievedUser;

                List<Transaction> ReturnedTransactions = _context.Transactions.Where(transaction => transaction.UserId == RetrievedUser.UserId).OrderByDescending(t => t.created_at).ToList();
                ViewBag.ReturnedTransactions = ReturnedTransactions;
                ViewBag.InvalidTransaction = TempData["InvalidTransaction"];
                return View("Account");
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        [Route("createtransaction")]
        public IActionResult CreateTransaction(Transaction transact) {
            HttpContext.Session.SetString("InvalidTransaction", "");
            if (ModelState.IsValid && HttpContext.Session.GetInt32("CurrentUserId") != null) {
                Transaction NewTrans = new Transaction {
                    Amount = Convert.ToDouble(transact.Amount),
                    UserId = (int)HttpContext.Session.GetInt32("CurrentUserId"),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                User RetrievedUser = _context.Users.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("CurrentUserId"));
                if ((RetrievedUser.AccountBalance + NewTrans.Amount) < 0) {
                    TempData["InvalidTransaction"] = "Withdrawal exceeds account balance.";
                    return RedirectToAction("Account");
                }

                _context.Add(NewTrans);
                _context.SaveChanges();

                List<Transaction> ReturnedValues = _context.Transactions.Where(transaction => transaction.UserId == RetrievedUser.UserId).ToList();
                int sum = (int)ReturnedValues.Sum(s => s.Amount);
                RetrievedUser.AccountBalance = sum;
                _context.SaveChanges();

                return RedirectToAction("Account");
            }
            return View("Account");
        }
    }
}