using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCaller;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 
namespace PokeInfo.Controllers
{
    public class PokeInfoController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {
        // A GET method
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            // var PokeInfo = new Dictionary<string, object>();
            var PokeObject = new Pokemon();
            
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    // PokeInfo = ApiResponse;
                    PokeObject = ApiResponse;
                }
            ).Wait();
            ViewBag.PokeInfo = PokeObject;
            Console.WriteLine(PokeObject.Name);
            return View("query-poke");
        }

    }
}