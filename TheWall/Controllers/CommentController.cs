using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using TheWall.Models;

namespace TheWall.Controllers

{
    public class CommentController : Controller
    {

        private readonly DbConnector _dbConnector;

        public CommentController(DbConnector connect) {
            _dbConnector = connect;
        }      

        [HttpGet]
        [Route("comments")]
        public IActionResult Comments()
        {
            List<Dictionary<string, object>> AllComments = _dbConnector.Query("SELECT * FROM comments");
            ViewBag.messages = AllComments;
            return View("Dashboard");
        }

        [HttpPost]
        [Route("comments")]
        public IActionResult Comments(Comment comment) {
            int user_id = (int)HttpContext.Session.GetInt32("UserId");
            Console.WriteLine("Comment:  " + comment.CommentText);
            Console.WriteLine("Message ID:  " + comment.MessageId);
            Console.WriteLine("User ID:  " + user_id); 
            if (ModelState.IsValid) {
                _dbConnector.CreateComment(comment.CommentText, user_id, comment.MessageId);
                return RedirectToAction("Dashboard", "Message");
            }
            ViewBag.error = "Please correct errors and resubmit.";
            return View("Dashboard", comment);
        }

        [HttpGet]
        [Route("cmtsuccess")]
        public IActionResult CmtSuccess() {
            return RedirectToAction("Dashboard");
        }
    }
}