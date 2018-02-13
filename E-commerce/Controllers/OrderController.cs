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
    public class OrderController : Controller
    {
        private E_CommerceContext _context;

        public OrderController(E_CommerceContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Orders() {
            List<Order> AllPopulatedOrders = _context.Orders.Include(c => c.Customer).Include(p => p.Product).ToList();
            ViewBag.allPopulatedOrders = AllPopulatedOrders;
            List<Customer> AllCustomers = _context.Customers.ToList();
            ViewBag.allCustomers = AllCustomers;
            List<Product> AllProducts = _context.Products.ToList();
            ViewBag.allProducts = AllProducts;
            return View("Orders");
        }

        [HttpPost]
        [Route("neworder")]
        public IActionResult NewOrder(Order model) {

            return RedirectToAction("Orders");
        }

    }
}