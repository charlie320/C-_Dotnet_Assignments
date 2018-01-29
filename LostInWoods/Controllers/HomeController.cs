using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace LostInWoods.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect) {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            // CreateTrail("East Texas Pines", "Beautiful wooded scenery", 4.0, 250, 32.3513, 'N', 95.3011, 'W');
            List<Dictionary<string,object>> AllTrails = _dbConnector.Query($"SELECT * FROM trails");
            ViewBag.trails = AllTrails;
            // Console.WriteLine(AllTrails[0]["trail_name"]);
            return View();
        }

        public List<Dictionary<string,object>> CreateTrail(string trail_name, string description, double trail_length, int elevation_change, double longitude, char longitude_hemisphere, double latitude, char latitude_hemisphere){
            List<Dictionary<string,object>> create = _dbConnector.Query("INSERT INTO trails (trail_name, description, trail_length, elevation_change, longitude, longitude_hemisphere, latitude, latitude_hemisphere, created_at, updated_at) VALUES (\"" + trail_name + "\", \"" + description + "\", \"" + trail_length + "\", \"" + elevation_change + "\", \"" + longitude + "\", \"" + longitude_hemisphere + "\", \"" + latitude + "\", \"" + latitude_hemisphere + "\", NOW(), NOW())");
            return create;
        }
        
    }
}
