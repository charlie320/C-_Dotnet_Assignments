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
        [Route("wedding/{weddingId}")]
        public IActionResult Wedding(int weddingId)
        {
            if (HttpContext.Session.GetInt32("CurrentUserId") != null) {
                Wedding RetrievedWedding = _context.Weddings.Where(w => w.WeddingId == weddingId).Include(g => g.GuestsAttending).ThenInclude(gA => gA.Guest).SingleOrDefault();
                ViewBag.wedding = RetrievedWedding;
                return View("Wedding");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("newwedding")]
        public IActionResult NewWedding() {
            if (HttpContext.Session.GetInt32("CurrentUserId") != null) {
                return View("NewWedding");
            }
            return RedirectToAction("Index", "Home");
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
        [Route("delete/{weddingId}")]
        public IActionResult Delete(int weddingId) {
            if (HttpContext.Session.GetInt32("CurrentUserId") != null) {
                Wedding RetrievedWedding = _context.Weddings.Where(w => w.WeddingId == weddingId).SingleOrDefault();
                _context.Weddings.Remove(RetrievedWedding);
                // _context.SaveChanges();

                WeddingConfirmation RetrievedWeddingConfirmation = _context.WeddingConfirmations.Where(w => w.WeddingId == weddingId).SingleOrDefault();
                _context.WeddingConfirmations.Remove(RetrievedWeddingConfirmation);
                _context.SaveChanges();

            return RedirectToAction("Dashboard", "Home");
            }
            return ViewBag("Index");
        }

        [HttpGet]
        [Route("allweddings")]
        public IActionResult AllWeddings() {
            if (HttpContext.Session.GetInt32("CurrentUserId") != null) {
                List<Wedding> AllWeddings = _context.Weddings.ToList();
                ViewBag.allWeddings = AllWeddings;
                return View("AllWeddings");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}