using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
 
namespace YourNamespace.Controllers
{
    public class RandomPasscodeController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {

        // A GET method
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            HttpContext.Session.SetInt32("passcodeCount", 0);
            return View("index");
        }

        // [HttpGet]
        // [Route("newnumber")]
        // // public IActionResult NewNumber() {
        // public int NewNumber() {            
        //     @ViewBag.randomString = GenRanString();
        //     int? psCount = HttpContext.Session.GetInt32("passcodeCount");
        //     int psIntCount = (int)psCount;
        //     psIntCount++;
        //     ViewBag.numCount = psIntCount;
        //     HttpContext.Session.SetInt32("passcodeCount", psIntCount);
        //     // return View("index");
        //     return (psIntCount);
        // }

        [HttpGet]
        [Route("newnumber")]
        public int NewNumber() {            
            int? psCount = HttpContext.Session.GetInt32("passcodeCount");
            int psIntCount = (int)psCount;
            psIntCount++;
            @ViewBag.numCount = psIntCount;
            HttpContext.Session.SetInt32("passcodeCount", psIntCount);
            return (psIntCount);
        }        

        [HttpGet]
        [Route("randomstring")]
        public string GenRanString(){
            Random rand = new Random();
            string newString = "";
            int newChar;
            int countChars = 0;

            while ( countChars < 14) {
                newChar = rand.Next(65,123);
                if ((newChar >= 65 && newChar <= 90) || (newChar >= 97 && newChar <= 122)) {
                    newString += (char)newChar;
                    countChars++;
                }
            }

            return newString;
        }

    }
}