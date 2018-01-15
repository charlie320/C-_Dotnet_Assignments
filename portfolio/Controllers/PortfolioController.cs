using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class PortfolioController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {
        // A GET method
        // [HttpGet]
        // [Route("index")]
        // public string Index()
        // {
        //     return "Welcome to Portfolio app!";
        // }

        // A GET method
        [HttpGet]
        [Route("home")]
        public IActionResult Home()
        {
            return View("home");
        }

        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            return View("projects");
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("contact");
        }                
        
    }
}