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
            return View("Register");
        }

        [HttpPost]
        [Route("")]
        public IActionResult Register(User user) {

            if (ModelState.IsValid) {
                return View("success");
            }
            
            return View(user);
        }
    }
}
