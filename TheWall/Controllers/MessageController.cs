using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using TheWall.Models;

namespace TheWall.Controllers

{
    public class MessageController : Controller
    {

        private readonly DbConnector _dbConnector;

        public MessageController(DbConnector connect) {
            _dbConnector = connect;
        }      

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            List<Dictionary<string, object>> AllMessages = _dbConnector.Query("SELECT * FROM messages");
            foreach (var message in AllMessages) {
                Console.WriteLine(message["id"]);
                List<Dictionary<string,object>> AllComments = _dbConnector.Query($"SELECT * FROM comments WHERE messages_id = {message["id"]}");
                foreach (var comment in AllComments) {
                    Console.WriteLine(comment["comment"]);
                }
                // Console.WriteLine(AllComments);
            }
            ViewBag.messages = AllMessages;
            // Console.WriteLine("Hello");
            // Console.WriteLine(ViewBag.messages);
            return View("Dashboard");
        }

        [HttpPost]
        [Route("dashboard")]
        public IActionResult Dashboard(Message message) {
            Console.WriteLine("Inside the Dashboard method.");
            int user_id = 3;  // Temporary hard-coded user_id
            if (ModelState.IsValid) {
                _dbConnector.CreateMessage(message.MessageText, user_id);
                return RedirectToAction("Dashboard");
            }
            ViewBag.error = "Please correct errors and resubmit.";
            return View("Dashboard", message);
        }

        [HttpGet]
        [Route("msgsuccess")]
        public IActionResult MsgSuccess() {
            return RedirectToAction("Dashboard");
        }
    }
}