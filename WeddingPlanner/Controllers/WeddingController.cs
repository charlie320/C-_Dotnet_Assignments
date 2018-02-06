using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {

        private WeddingPlannerContext _context;

        public WeddingController(WeddingPlannerContext context) {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("wedding/{id}")]
        public IActionResult Wedding()
        {
            
            return View("Wedding");
        }

        [HttpGet]
        [Route("newwedding")]
        public IActionResult NewWedding() {

            return View("NewWedding");
        }

        [HttpPost]
        [Route("createwedding")]
        public IActionResult CreateWedding(Wedding model) {
            
            if(ModelState.IsValid && HttpContext.Session.GetInt32("CurrentUserId") != null) {
                Wedding wedding = new Wedding {
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    WeddingAddress = model.WeddingAddress,
                    PlannerId = (int)HttpContext.Session.GetInt32("CurrentUserId"),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                _context.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }

            // *****One way to extract validation errors*****
            // foreach (var modelState in ModelState.Values) {
            //     foreach (ModelError error in modelState.Errors) {
            //         Console.WriteLine(error.ErrorMessage);
            //     }
            // }

            // *****Another way to extract validation errors.  However, Web app will utilize @Http.ValidationSummary() on client side to display errors*****
            // IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            // ViewBag.errors = allErrors;

            return View("Index", "Home");
        }

        [HttpGet]
        [Route("allweddings")]
        public IActionResult AllWeddings() {
            List<Wedding> AllWeddings = _context.Weddings.ToList();
            ViewBag.allWeddings = AllWeddings;
            return View("AllWeddings");
        }
    }
}
