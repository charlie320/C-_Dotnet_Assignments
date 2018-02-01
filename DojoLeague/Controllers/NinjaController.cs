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
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            // NinjaFactory ninjaFactory = new NinjaFactory();
            ninjaFactory = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Ninjas()
        {
            //We can call upon the methods of the userFactory directly now.
            ViewBag.ninjas = ninjaFactory.FindAll();
            return View("ninjas");
        }
    }
}