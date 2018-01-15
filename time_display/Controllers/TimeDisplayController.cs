using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace YourNamespace.Controllers
{
    public class TimeDisplayController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {
        // A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }
        
        // A POST method
        [HttpPost]
        [Route("")]
        // public IActionResult Other()
        public string Other() // Temporary line in place of IActionResult
        {
            // Return a view (We'll learn how soon!)
            return "Hello World!";  //  temporary line for now
        }

        [HttpGet]
        [Route("")]
        public IActionResult DateTime()
        {
            return View("Index");
        }        
    }
}