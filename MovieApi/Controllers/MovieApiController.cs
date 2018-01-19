using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using ApiCaller;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonData;

namespace MovieApi.Controllers
{
    public class MovieApiController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {

        // A GET method
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
        public IActionResult SearchMovie(string movie)
        {
            // var MovieInfo = new Dictionary<string, object>();
            var MovieObject = new Movie();
            
            WebRequest.GetMovieDataAsync(movie, ApiResponse =>
                {
                    MovieObject = ApiResponse;
                }
            ).Wait();

            ViewBag.MovieInfo = MovieObject;
            Console.WriteLine(MovieObject);
            // Console.WriteLine(MovieInfo["results"]);
            return RedirectToAction("Index");  //  temporary line for now
        }
    }
}