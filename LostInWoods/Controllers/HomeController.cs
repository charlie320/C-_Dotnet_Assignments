using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using LostInWoods.Factory;
using LostInWoods.Models;

namespace LostInWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;

        public HomeController(TrailFactory connect) {
            trailFactory = connect;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("newtrail")]
        public IActionResult NewTrail() {
            return View("newtrail");
        }

        [HttpGet]
        [Route("showtrail/{id}")]
        public IActionResult ShowTrail(int id) {
            ViewBag.trail = trailFactory.FindByID(id);
            return View("showtrail", id);
        }

        [HttpPost]
        [Route("createtrail")]
        public IActionResult CreateTrail(Trail trail) {
            if (ModelState.IsValid) {
                trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return RedirectToAction("NewTrail");

        }
        
    }
}
