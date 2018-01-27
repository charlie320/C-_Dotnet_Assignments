using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect) {
            _dbConnector = connect;
        }      

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("registerform")]
        public IActionResult RegisterForm() {
            return PartialView("~/Views/Shared/_Registration.cshtml");
        }

        [HttpPost]
        [Route("")]
        [Route("index")]
        public IActionResult Index(User user) {
            Console.WriteLine(user.FirstName);
            if (ModelState.IsValid) {
                _dbConnector.Create(user.FirstName, user.LastName, user.EmailAddress, user.Password);
                return RedirectToAction("RegSuccess");
            }
            ViewBag.IsValid = false;
            return View("_Registration", user);
        }

        [HttpGet]
        [Route("regsuccess")]
        public IActionResult RegSuccess() {
            return View("_RegSuccess");
        }

        [HttpGet]
        [Route("loginform")]
        public IActionResult LoginForm() {
            return PartialView("~/Views/Shared/_Login.cshtml");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string emailAddress, string password) {
        List<Dictionary<string, object>>passwordCheck = _dbConnector.Query($"SELECT id, password FROM users WHERE(email = \"{emailAddress}\")");       
            if (ModelState.IsValid) {
                // foreach(var pass in passwordCheck) {
                //     foreach(var word in pass) {
                //         Console.WriteLine(word);
                //         if (word.Value.ToString() == password) {
                //             return RedirectToAction("Dashboard", "Message");
                //         }
                //     }
                // }

                if ((string)passwordCheck[0]["password"] == password) {

                    HttpContext.Session.SetString("UserEmail", $"{emailAddress}");
                    int user_id = (int)passwordCheck[0]["id"];
                    HttpContext.Session.SetInt32("UserId", user_id);

                    Console.WriteLine("Session user_email:  " + HttpContext.Session.GetString("UserEmail"));
                    Console.WriteLine("Session id:  " + HttpContext.Session.GetInt32("UserId"));

                    return RedirectToAction("Dashboard", "Message");
                }
            }
            ViewBag.error = "Email address and/or password are invalid.";
            return View("_Login");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            Console.WriteLine("Logout email:  " + HttpContext.Session.GetString("UserEmail"));
            Console.WriteLine("Logout id:  " + HttpContext.Session.GetString("UserId"));

            return RedirectToAction("Index");
        }
    }
}