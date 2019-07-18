using POPS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POPS.WebUI.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        HttpResponseMessage response;
        // GET: PurchaseOrders
        public ActionResult Index()
        {
            IEnumerable<POMaster> poMasters;
            response = GlobalVariables.WebApiClient.GetAsync("PurchaseOrders").Result;
            poMasters = response.Content.ReadAsAsync<IEnumerable<POMaster>>().Result;
            return View(poMasters);
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int id)
        {
            POMaster poMaster = new POMaster();
            HttpResponseMessage response;
            if (id > 0)
            {
                response = GlobalVariables.WebApiClient.GetAsync("PurchaseOrders/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    poMaster = response.Content.ReadAsAsync<POMaster>().Result;
                }
                else if (response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
                }
            }

            return View(poMaster);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            return View(new POMaster());
        }

        // POST: PurchaseOrders/Create
        [HttpPost]
        public ActionResult Create(POMaster poMaster)
        {
            try
            {
                // TODO: Add insert logic here
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("PurchaseOrders", poMaster).Result;
                TempData["SuccessMessage"] = "Purchase Order saved Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(int id)
        {
            POMaster poMaster = new POMaster();
            if (id > 0)
            {
                response = GlobalVariables.WebApiClient.GetAsync("PurchaseOrders/" + id).Result;
                poMaster = response.Content.ReadAsAsync<POMaster>().Result;
            }
            return View(poMaster);
        }

        // POST: PurchaseOrders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, POMaster poMaster)
        {
            try
            {
               response = GlobalVariables.WebApiClient.PutAsJsonAsync("PurchaseOrders/" + id, poMaster).Result;
                TempData["SuccessMessage"] = "Purchase order updated Successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                response = GlobalVariables.WebApiClient.DeleteAsync("PurchaseOrders/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Purchase order deleted Successfully!";
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
