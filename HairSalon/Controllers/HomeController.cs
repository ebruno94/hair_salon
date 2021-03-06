using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View(Stylist.GetAllStylists());
        }

        [HttpGet("/Delete_All")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();

            return RedirectToAction("Index", "Home");
        }

    }
}
