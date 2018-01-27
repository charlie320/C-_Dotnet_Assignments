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
            int message_id = 2; // Temporary hard-coded message_id
            if (ModelState.IsValid) {
                _dbConnector.CreateComment(comment.CommentText, user_id, message_id);
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