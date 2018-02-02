using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;
using System.Linq;
using DbConnection;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RESTauranterContext _context;
 
        public HomeController(RESTauranterContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews() {
            List<Review> AllReviews = _context.Reviews.OrderByDescending(r => r.created_at).ToList();
            ViewBag.reviews = AllReviews;
            return View("Reviews");
        }

        [HttpPost]
        [Route("createreview")]
        public IActionResult CreateReview(Review review) {
            review.created_at = DateTime.Now;
            review.updated_at = DateTime.Now;
            _context.Add(review);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }

        [HttpGet]
        [Route("reviews/{id}/helpful/{response}")]
        public IActionResult Helpful(int id, string response) {
            Review RetrievedReview = _context.Reviews.SingleOrDefault(review => review.review_id == id);
            if (response == "yes") {
                RetrievedReview.Helpful++;
            } else {
                RetrievedReview.Unhelpful++;
            }
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }
    }
}
