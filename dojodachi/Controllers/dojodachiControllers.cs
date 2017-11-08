using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dojodachi.Controllers
{
    public class dojodachiController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("happiness") == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetInt32("energy", 50);
                HttpContext.Session.SetInt32("meals", 3);
            }
            ViewBag.SuccessorFail = HttpContext.Session.GetInt32("SuccessorFail");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            ViewBag.meals = HttpContext.Session.GetInt32("meals");
            return View("Home");
        }
        [HttpGet]
        [Route("Feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int randNum = rand.Next(5, 10);
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            meals -= 1;
            fullness += randNum;
            HttpContext.Session.SetInt32("meals", (Int32)meals);
            HttpContext.Session.SetInt32("fullness", (Int32)fullness);
            ViewBag.meals = meals;
            ViewBag.fullness = fullness;
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("Sleep")]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("energy");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            HttpContext.Session.SetInt32("energy", (Int32)energy);
            HttpContext.Session.SetInt32("happiness", (Int32)happiness);
            HttpContext.Session.SetInt32("fullness", (Int32)fullness);
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("Work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");
            energy -= 5;
            meals += rand.Next(1, 3);
            HttpContext.Session.SetInt32("meals", (Int32)meals);
            HttpContext.Session.SetInt32("energy", (Int32)energy);
            return RedirectToAction("Home");
        }
        [HttpGet]
        [Route("Play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            energy -= 5;
            happiness += rand.Next(5, 10);
            HttpContext.Session.SetInt32("energy", (Int32)energy);
            HttpContext.Session.SetInt32("happiness", (Int32)happiness);
            return RedirectToAction("Home");
        }
    }
}