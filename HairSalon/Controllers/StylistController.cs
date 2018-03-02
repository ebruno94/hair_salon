using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/Stylist/Form")]
        public ActionResult ViewForm()
        {
            return View("Form");
        }

        [HttpPost("Stylist/Create")]
        public ActionResult Create()
        {
            string name = Request.Form["stylistName"];
            string number = Request.Form["stylistNumber"];
            string specialty = Request.Form["stylistSpecial"];
            Stylist myStylist = new Stylist(name, number);
            myStylist.Save();
            Console.WriteLine(myStylist.GetId());
            Specialty newSpecialty = new Specialty(specialty);
            newSpecialty.Save();
            newSpecialty.AddStylist(myStylist);
            myStylist.AddSpecialty(newSpecialty);
            return View("Info", myStylist);
        }

        [HttpGet("Stylist/Info/{id}")]
        public ActionResult Info(int id)
        {
            ViewBag.StylistId = id;
            return View(Stylist.Find(id));
        }

    }
}
