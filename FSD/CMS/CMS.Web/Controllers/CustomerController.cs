using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    public class CustomerController : Controller
    {
        CustomerContext context = new CustomerContext();
        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            customers = context.GetAllCustomers().ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.AddCustomer(customer);
                TempData["SuccessMessage"] = $"{customer.Name} saved Successfully!";
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = context.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.UpdateCustomer(customer);
                TempData["SuccessMessage"] = $"{customer.Name} updated Successfully!";
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = context.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer customer = context.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            context.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        public IActionResult Search()
        {
            List<Customer> customers = new List<Customer>();
            customers = context.GetAllCustomers().ToList();

            return View(customers);
        }

        [HttpPost, ActionName("Search")]
        public IActionResult Search(DateTime? dob)
        {
            List<Customer> customers = new List<Customer>();
            customers = context.GetAllCustomers().ToList();

            return View(customers);
        }
    }
}