using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginReg.Models;
using DbConnection;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect) {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            return View("register");
        }

        [HttpPost]
        [Route("")]
        public IActionResult Register(User user) {
            if(ModelState.IsValid) {
                _dbConnector.Create(user.FirstName, user.LastName, user.EmailAddress, user.Password);
                return View("success");
            }
            return View(user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string emailAddress, string password) {
            List<Dictionary<string, object>>passwordCheck = _dbConnector.Query($"SELECT Password FROM users WHERE(email = \"{emailAddress}\")");
            if (ModelState.IsValid) {
                foreach(var pass in passwordCheck) {
                    foreach(var word in pass) {
                        if (word.Value.ToString() == password) {
                            return View("success-login");
                        }
                    }
                }
            }
            ViewBag.error = "User email and/or password not found";
            return View("register");
        }
    }
}
