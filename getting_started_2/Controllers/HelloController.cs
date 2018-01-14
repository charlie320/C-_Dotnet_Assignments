using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {
        // A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "My first ASP.NET app get route!";
        }

        [HttpGet]
        [Route("displayint")]
        public JsonResult displayInt()
        {
            return Json(34);
        }

        [HttpGet]
        [Route("displayjson")]
        public JsonResult displayJson()
        {
            var AnonObject = new {
                FirstName = "Raz",
                LastName = "Aquato",
                Age = 10
            };

            return Json(AnonObject);
        }

        // A POST method
        [HttpPost]
        [Route("")]
        // public IActionResult Other()
        public string Other()  // Temporary line in place of IActionResult
        {
            // Return a view (We'll learn how soon!)
            return "Hello World!";  // Temporary line for now.
        }
    }
}