using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;

        public NinjaController(NinjaFactory connect)
        {
            ninjaFactory = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Ninjas()
        {
            //We can call upon the methods of the userFactory directly now.
            ViewBag.ninjas = ninjaFactory.FindAllWithDojo();
            ViewBag.rogueNinjas = ninjaFactory.FindAllWithDojoNull();
            return View("ninjas");
        }

        [HttpGet]
        [Route("ninjas/{id}")]
        public IActionResult NinjaShow(int id) {
            // ViewBag.ninja_id = id;
            ViewBag.ninja = ninjaFactory.FindById(id);
            ViewBag.ninjaDojo = ninjaFactory.FindNinjaDojo(ViewBag.ninja.dojos_id);
            return View("NinjaShow");
        }
    }
}