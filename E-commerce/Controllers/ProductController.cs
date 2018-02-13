using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_Commerce.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private E_CommerceContext _context;

        public ProductController(E_CommerceContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Products() {
         
            return View("Products");
        }


    }
}