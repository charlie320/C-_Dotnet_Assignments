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

        // private readonly DbConnector _dbConnector; 
        private readonly TrailFactory trailFactory;

        // public HomeController(DbConnector connect) {
        public HomeController(TrailFactory connect) {
            
            // _dbConnector = connect;
            trailFactory = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            // CreateTrail("East Texas Pines", "Beautiful wooded scenery", 4.0, 250, 32.3513, 'N', 95.3011, 'W');

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

            return View("showtrail", id);
        }

        [HttpPost]
        [Route("createtrail")]
        public IActionResult CreateTrail(Trail trail) {
            Console.WriteLine("Inside the CreateTrail method.");
            trailFactory.Add(trail);
            return RedirectToAction("Index");
        }

        // public List<Dictionary<string,object>> CreateTrail(string trail_name, string description, double trail_length, int elevation_change, double longitude, char longitude_hemisphere, double latitude, char latitude_hemisphere){
        //     List<Dictionary<string,object>> create = _dbConnector.Query("INSERT INTO trails (trail_name, description, trail_length, elevation_change, longitude, longitude_hemisphere, latitude, latitude_hemisphere, created_at, updated_at) VALUES (\"" + trail_name + "\", \"" + description + "\", \"" + trail_length + "\", \"" + elevation_change + "\", \"" + longitude + "\", \"" + longitude_hemisphere + "\", \"" + latitude + "\", \"" + latitude_hemisphere + "\", NOW(), NOW())");
        //     return create;
        // }
        
    }
}
