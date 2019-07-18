using POPS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace POPS.WebUI.Controllers
{
    public class ItemsController : Controller
    {
        HttpResponseMessage response;
        // GET: Items
        public ActionResult Index()
        {
            IEnumerable<Item> items;
            response = GlobalVariables.WebApiClient.GetAsync("Items").Result;
            items = response.Content.ReadAsAsync<IEnumerable<Item>>().Result;
            return View(items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            Item item = new Item();
            if (id > 0)
            {
                response = GlobalVariables.WebApiClient.GetAsync("Items/" + id).Result;
                item = response.Content.ReadAsAsync<Item>().Result;
            }

            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View(new Item());
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Items", item).Result;
                TempData["SuccessMessage"] = "Item saved Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            Item item = new Item();
            if (id > 0)
            {
                response = GlobalVariables.WebApiClient.GetAsync("Items/" + id).Result;
                item = response.Content.ReadAsAsync<Item>().Result;
            }
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Items/" + id, item).Result;
                TempData["SuccessMessage"] = "Item updated Successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
         public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                response = GlobalVariables.WebApiClient.DeleteAsync("Items/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Item deleted Successfully!";
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
