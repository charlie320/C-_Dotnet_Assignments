using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace movie_api.Controllers
{
    public class MovieApiController : Controller
    {
        private readonly DbConnector _dbConnector;

        public MovieApiController(DbConnector connect) {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            Dictionary<string,string> myDict = new Dictionary<string,string>() {{"red","#ff0000"},{"green","#00ff00"},{"blue","#0000ff"},{"gray","#777777"}};
            ViewBag.colors = myDict;
            return View("index");
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search(string movie) {
            Console.WriteLine(movie);
            // make webrequest here.  Left off 1/16/18 @ 10:30.  See ApiCaller.cs
            return RedirectToAction("Index");
        }

    }
}
