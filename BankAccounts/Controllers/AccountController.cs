using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace BankAccounts.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("account")]
        public IActionResult Account()
        {
            return View("Account");
        }
    }
}
