using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpPost("/Client/Create")]
        public ActionResult Create()
        {
            string name = Request.Form["clientName"];
            string number = Request.Form["clientNumber"];
            Client newClient = new Client(name, number);
            newClient.Save();
            return RedirectToAction("Info", "Stylists");
        }

        [HttpGet("/Client/Info/{id}")]
        public ActionResult Info(int id)
        {
            Client myClient = Client.Find(id);
            return View(myClient);
        }

        [HttpGet("/Client/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Client myClient = Client.Find(id);
            myClient.Delete();
            return RedirectToAction("Info", "Stylists");
        }
    }
}
