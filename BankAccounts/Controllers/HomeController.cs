using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            return View("Index");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string Email, string PasswordToCheck) {
            return View("Login");
        }

        [HttpGet]
        [Route("account")]
        public IActionResult Account() {
            List<User> Users = _context.Users.Include(user => user.Transactions).ToList();
            return View("Account");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user) {
            
            if(ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
            }

            return RedirectToAction("Login");
        }
    }
}