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
            if (HttpContext.Session.GetInt32("UserId") != null) {
            List<Dictionary<string, object>> AllMessages = _dbConnector.Query("SELECT * FROM messages");
            List<Dictionary<string, object>> AllComments = _dbConnector.Query("SELECT * FROM comments");
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            Console.WriteLine(AllUsers[0]["first_name"]);
            ViewBag.messages = AllMessages;
            ViewBag.comments = AllComments;
            ViewBag.users = AllUsers;
            ViewBag.userId = HttpContext.Session.GetInt32("UserId");

            return View("Dashboard");
            } else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Route("dashboard")]
        public IActionResult Dashboard(Message message) {
            int user_id = (int)HttpContext.Session.GetInt32("UserId");
            Console.WriteLine("dashboard post user_id = " + user_id);

            if (ModelState.IsValid) {
                _dbConnector.CreateMessage(message.MessageText, user_id);
                return RedirectToAction("Dashboard");
            }
            ViewBag.error = "Please correct errors and resubmit.";
            return View("Dashboard", message);
        }

        [HttpGet]
        [Route("msgsuccess/")]
        public IActionResult MsgSuccess() {
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        [Route("removemessage")]
        public IActionResult RemoveMessage(Message message) {
            Console.WriteLine($"Message Id number {message.Id} received in the RemoveMessage method.");
            // string DeleteMessage = _dbConnector.DeleteMessage(message.Id);
            // Console.WriteLine(DeleteMessage);
            return View("removesuccess");
        }
    }
}