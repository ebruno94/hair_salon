using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/Specialties/ViewAll")]
        public ActionResult ViewAll()
        {
            return View(Specialty.GetAll());
        }
    }
}
