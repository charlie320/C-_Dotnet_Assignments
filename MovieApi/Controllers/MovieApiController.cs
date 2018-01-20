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
        private readonly DbConnector _dbConnector;

        public MovieApiController(DbConnector connect) {
            _dbConnector = connect;
        }

        // A GET method
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            Dictionary<string,string> myDict = new Dictionary<string,string>() {{"red","#ff0000"},{"green","#00ff00"},{"blue","#0000ff"},{"gray","#777777"}};
            ViewBag.colors = myDict;
            return View("index-ajax");
        }

        [HttpPost]
        [Route("search")]
        public IActionResult SearchMovie(string movie)
        
        {
            var MovieObject = new Movie();
            
            WebRequest.GetMovieDataAsync(movie, ApiResponse =>
                {
                    MovieObject = ApiResponse;
                }
            ).Wait();

            List<Dictionary<string,object>> AllMovies = _dbConnector.Create(MovieObject.Title,MovieObject.VoteAverage,MovieObject.ReleaseDate);
            // ViewBag.AllMovies = AllMovies;
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("getmovies")]
        public List<Dictionary<string,object>> GetMovies() {
            List<Dictionary<string,object>> MovieList = new List<Dictionary<string,object>>();
            MovieList = _dbConnector.Query("SELECT* FROM movies");
            return MovieList;
        }


    }
}