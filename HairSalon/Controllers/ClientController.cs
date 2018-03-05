using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/Clients/ViewAll")]
        public ActionResult ViewAll()
        {
            List<Client> clients = Client.GetAll();
            return View(clients);
        }

        [HttpPost("/Client/Create/{id}")]
        public ActionResult Create(int id)
        {
            ViewBag.StylistId = id;
            string name = Request.Form["clientName"];
            string number = Request.Form["clientNumber"];
            Client newClient = new Client(name, number);
            newClient.Save();
            Stylist thisStylist = Stylist.Find(id);
            thisStylist.AddClient(newClient);
            return RedirectToAction("Info", "Stylists", new {id = id});
        }

        [HttpGet("/Client/Info/{stylistId}/{clientId}")]
        public ActionResult Info(int stylistId, int clientId)
        {
            ViewBag.StylistId = stylistId;
            ViewBag.ClientId = clientId;
            Client myClient = Client.Find(clientId);
            return View(myClient);
        }

        [HttpGet("/Client/Delete/{stylistId}/{clientId}")]
        public ActionResult Delete(int stylistId, int clientId)
        {
            ViewBag.StylistId = stylistId;
            ViewBag.ClientId = clientId;
            Client myClient = Client.Find(clientId);
            myClient.Delete();
            return RedirectToAction("Info", "Stylists", new {id = stylistId});
        }
    }
}
