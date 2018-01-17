using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace quoting_dojo.Controllers
{
    public class QuotingDojoController : Controller  // Name controller class after model such as "Hello" + "Controller"
    {
        private DbConnector cnx;

        public QuotingDojoController()
        {
            cnx = new DbConnector();
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            // List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes");
            string query = "SELECT * FROM quotes";
            var allQuotes = cnx.Query(query);
            ViewBag.allQuotes = allQuotes;
            return View("quotes");
        }

        [HttpPost]
        [Route("createquote")]
        public IActionResult CreateQuote(string name, string quote) // Temporary line in place of IActionResult
        {
            Console.WriteLine(name);
            Console.WriteLine(quote);
            string query = $"INSERT INTO quotes (user, quote, created_at, updated_at) VALUES ('{name}','{quote}', NOW(), NOW())";
            cnx.Execute(query);
            return RedirectToAction("Index");
        }
    }
}