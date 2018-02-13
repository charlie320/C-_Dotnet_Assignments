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
    public class CustomerController : Controller
    {
        private E_CommerceContext _context;

        public CustomerController(E_CommerceContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index() {
         
            return View("Index");
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Customers() {
            List<Customer> AllCustomers = _context.Customers.ToList();
            ViewBag.allCustomers = AllCustomers;
            return View("Customers");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(Customer model) {
            
            if(ModelState.IsValid) {
                Customer customer = new Customer {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpGet]
        [Route("allcustomers")]
        public IActionResult AllCustomers() {
                List<Customer> AllCustomers = _context.Customers.ToList();
                ViewBag.allCustomers = AllCustomers;
                return View("AllCustomers");
        }
    }
}