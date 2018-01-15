using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class DojoSurveyController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {
        // A GET method
        // [HttpGet]
        // [Route("index")]
        // public string Index()
        // {
        //     return "Dojo Survey app!";
        // }

        // A GET method
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet]
        [Route("result")]
        public IActionResult Result()
        {
            return View("result");
        }

        // A POST method
        [HttpPost]
        [Route("result")]
        // public IActionResult Other()
        public IActionResult FormInput(string name, string location, string language, string comment) // Temporary line in place of IActionResult
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("result");
        }
    }
}