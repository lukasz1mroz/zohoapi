using System;
using Microsoft.AspNetCore.Mvc;
using zohotest.Services;

namespace zohotest.Controllers
{
    public class HomeController : Controller
    {
        private IZohoService IZohoService;
        public HomeController(IZohoService iZohoService)
        {
            this.IZohoService = iZohoService;
        }

        // Change endpoints: 
        // index for setting accesses, 
        // create for adding customer, creating invoice and updating estock
        
        [HttpGet("")]
        public IActionResult Index(string message)
        {
            ViewData["Status"] = message;
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        // Put webhook object details in method arguments

        [HttpPost("contact")]
        public IActionResult Contact(string firstName, string lastName, string phone, string email, string country, string city, string street, string zip)
        {
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(country) || String.IsNullOrEmpty(city) || String.IsNullOrEmpty(street) || String.IsNullOrEmpty(zip))
            {
                ViewData["Error"] = "Please provide full contact data";
                return View();
            }
            IZohoService.CreateContact(firstName, lastName, phone, email, country, city, street, zip);
            return RedirectToAction("Index", new { message = "Contact added" });
        }

        [HttpGet("product")]
        public IActionResult Product()
        {
            return View();
        }

        [HttpPost("product")]
        public IActionResult Product(long? productId, long? stockAmount)
        {
            if (productId == null || stockAmount == null)
            {
                ViewData["Error"] = "Please provide full product data";
                return View();
            }
            IZohoService.UpdateProduct(productId, stockAmount);
            return RedirectToAction("Index", new { message = "Product updated" });
        }

        [HttpGet("invoice")]
        public IActionResult Invoice()
        {
            return View();
        }

        [HttpPost("invoice")]
        public IActionResult Invoice(string subject, long contactId, string productId, string pricebookId, string prodDescription, long quantity)
        {
            if (contactId == 0 || String.IsNullOrEmpty(productId) || quantity == 0)
            {
                ViewData["Error"] = "Please provide full invoice data";
                return View();
            }
            IZohoService.CreateInvoice(subject, contactId, productId, pricebookId, prodDescription, quantity);
            return RedirectToAction("Index", new { message = "Invoice created" });
        }

    }
}
