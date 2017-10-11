using Microsoft.AspNetCore.Mvc;
using System;
using Tamagotchi.Models;
using System.Collections.Generic;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("/pet/add"), ActionName("Index")]
        public ActionResult IndexAdd()
        {
            string type = Request.Form["type"];
            string name = Request.Form["name"];
            List<Pet> petList = Pet.AdoptPet(type, name);
            return View(petList);
        }
    }
}
