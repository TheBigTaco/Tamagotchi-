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
        [HttpPost("/pet/add")]
        public ActionResult PetAdd()
        {
            Pet newPet = new Pet(Request.Form["name"]);
            Pet.Time(1);
            return View(Pet.GetList());
        }
        [HttpPost("/pet/thirst/{id}"), ActionName("PetAdd")]
        public ActionResult PetWater(int id)
        {
            Pet.GetList()[id].ChangePetStatus(10,0,0);
            Pet.Time(1);
            return View(Pet.GetList());
        }
        [HttpPost("/pet/hunger/{id}"), ActionName("PetAdd")]
        public ActionResult PetFood(int id)
        {
            Pet.GetList()[id].ChangePetStatus(0,10,0);
            Pet.Time(1);
            return View(Pet.GetList());
        }
        [HttpPost("/pet/sleep/{id}"), ActionName("PetAdd")]
        public ActionResult PetSleep(int id)
        {
            Pet.GetList()[id].ChangePetStatus(0,0,10);
            Pet.Time(1);
            return View(Pet.GetList());
        }
        [HttpPost("/pet/time"), ActionName("PetAdd")]
        public ActionResult PetTime()
        {
            Pet.Time(10);
            return View(Pet.GetList());
        }
    }
}
