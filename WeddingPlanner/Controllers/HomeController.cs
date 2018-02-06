using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private WeddingPlannerContext _context;

        public HomeController(WeddingPlannerContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index() {
            HttpContext.Session.Clear();
            ViewBag.InitSession = HttpContext.Session;
            return View("Index");
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
                    return RedirectToAction("Dashboard");
                }
            }
            ViewBag.error = "Login information is invalid.";
            return View("Login");
        }

        [HttpGet]
        [Route("registerform")]
        public IActionResult RegisterForm() {
            HttpContext.Session.Clear();
            ViewBag.InitSession = HttpContext.Session;
            return View("Register");
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
        [Route("dashboard")]
        public IActionResult Dashboard() {
            List<Wedding> AllWeddings = _context.Weddings.ToList();
            ViewBag.allWeddings = AllWeddings;
            User CurrentUser = _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("CurrentUserId"));
            ViewBag.currentUser = CurrentUser;
            return View("Dashboard");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("allusers")]
        public IActionResult AllUsers() {
            List<User> AllUsers = _context.Users.ToList();
            ViewBag.allUsers = AllUsers;
            return View("AllUsers");
        }
    }
}
