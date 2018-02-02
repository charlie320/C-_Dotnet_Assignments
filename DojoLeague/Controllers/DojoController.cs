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
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;

        public DojoController(DojoFactory connect)
        {
            dojoFactory = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("dojos")]
        public IActionResult Dojos()
        {
            //We can call upon the methods of the dojoFactory directly now.
            ViewBag.dojos = dojoFactory.FindAll();
            return View("dojos");
        }

        [HttpPost]
        [Route("adddojo")]
        public IActionResult AddDojo(Dojo dojo) {
            if (ModelState.IsValid) {
                dojoFactory.Add(dojo);
                return RedirectToAction("Dojos");
            }
            ViewBag.dojos = dojoFactory.FindAll();
            return View("Dojos");
        }

        [HttpGet]
        [Route("dojos/{id}")]
        public IActionResult DojoShow(int id) {
            ViewBag.dojo_id = id;
            ViewBag.dojoWithNinjas = dojoFactory.FindByIdWithNinjas(id);
            ViewBag.rogueNinjas = dojoFactory.GetRogueNinjas();
            return View("DojosShow");
        }

        [HttpGet]
        [Route("dojos/{dojo_id}/banish/{ninja_id}")]
        public IActionResult Banish(int dojo_id, int ninja_id) {
            dojoFactory.BanishNinja(ninja_id);
            return RedirectToAction("DojoShow", new {id = dojo_id});

        }

        [HttpGet]
        [Route("dojos/{dojo_id}/recruit/{ninja_id}")]
        public IActionResult RecruitNinja(int dojo_id, int ninja_id){
            dojoFactory.RecruitNinja(dojo_id,ninja_id);
            return RedirectToAction("DojoShow", new { id = dojo_id});
        }
    }
}