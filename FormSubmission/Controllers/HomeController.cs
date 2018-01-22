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
        [Route("index")]
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

            if (!ModelState.IsValid) {
                List<string> myStringList = new List<string>();

                foreach(var errorCollection in ModelState.Values) {
                    foreach( var errorMessageCollection in errorCollection.Errors) {
                        myStringList.Add(errorMessageCollection.ErrorMessage);
                    }
                }

                ViewBag.errors = myStringList;
                Console.WriteLine(ViewBag.errors);

                return View("index");
            }

            return View("success");
        }
    }
}
