using POPS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POPS.WebUI.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            IEnumerable<Supplier> suppliers;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Suppliers").Result;
            suppliers = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            return View(suppliers);
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id = 0)
        {
            Supplier supplier = new Supplier();
            HttpResponseMessage response;
            if (id > 0)
            {
                response = GlobalVariables.WebApiClient.GetAsync("Suppliers/" + id).Result;
                supplier = response.Content.ReadAsAsync<Supplier>().Result;
            }

            return View(supplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View(new Supplier());
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Suppliers", supplier).Result;
                TempData["SuccessMessage"] = "Supplier saved Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            Supplier supplier = new Supplier();
            HttpResponseMessage response;
            if (id > 0)
            {
                response = GlobalVariables.WebApiClient.GetAsync("Suppliers/" + id).Result;
                supplier = response.Content.ReadAsAsync<Supplier>().Result;
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier supplier)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Suppliers/" + id, supplier).Result;
                TempData["SuccessMessage"] = "Supplier updated Successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Supplier/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Supplier/Delete/5
        //[HttpPost]

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Suppliers/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Supplier deleted Successfully!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
