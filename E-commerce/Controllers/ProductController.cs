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
            List<Product> AllProducts = _context.Products.ToList();
            ViewBag.allProducts = AllProducts;
            return View("Products");
        }

        [HttpPost]
        [Route("newproduct")]
        public IActionResult NewProduct(Product model) {
                if(ModelState.IsValid) {
                Product product = new Product {
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = "/Images/" + model.ImageUrl + ".jpg",
                    QuantityAvailable = model.QuantityAvailable,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            return View("Products");
        }

        [HttpGet]
        [Route("allproducts")]
        public IActionResult AllProducts() {
            List<Product> AllProducts = _context.Products.ToList();
            ViewBag.allProducts = AllProducts;
            return View("AllProducts");
        }


    }
}