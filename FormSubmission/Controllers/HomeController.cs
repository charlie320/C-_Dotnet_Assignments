using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Submitform(string first_name, string last_name, int age, string email, string password) {
            User NewUser = new User {
                FirstName = first_name,
                LastName = last_name,
                Age = age,
                EmailAddress = email,
                Password = password
            };
            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            ViewBag.sanitytest = "Successfully registered!";
            return View("success");
        }
    }
}
