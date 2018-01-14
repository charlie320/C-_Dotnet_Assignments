using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
 
namespace CallingCard.Controllers
{
    public class CallingCardController : Controller
    {

    [HttpGet]
    [Route("")]
    public IActionResult Index() {
        return View("Index");
    }

    [HttpGet]
    [Route("input/{first_name},{last_name},{age},{favorite_color}")]
    public IActionResult Method(string first_name, string last_name, int age, string favorite_color) {
        List<object> myList = new List<object>();
            myList.Add(first_name);
            myList.Add(last_name);
            myList.Add(age);
            myList.Add(favorite_color);
        return Json(myList);
    }

    [HttpGet]
    [Route("displayjson")]
    public JsonResult DisplayJson()
        {
            var AnonObject = new {
                                FirstName = "Raz",
                                LastName = "Aquato",
                                Age = 10
                            };
            return Json(AnonObject);
        }
    }
}