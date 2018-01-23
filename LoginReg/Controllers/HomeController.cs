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
            return View("index");
        }

        [HttpPost]
        [Route("")]
        public IActionResult Index(User user) {
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
            ViewBag.error = "The username and/or password are invalid.";
            return View("index");
        }
    }
}
