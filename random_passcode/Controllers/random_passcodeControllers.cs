using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace random_passcode.Controllers
{
     public class random_passcodeController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
           if (HttpContext.Session.GetInt32("Count") == null){
                HttpContext.Session.SetInt32("Count",0);
            }

            int? Count2 = HttpContext.Session.GetInt32("Count") + 1;
            HttpContext.Session.SetInt32("Count", (int)Count2);


            string Choices = "ABCDEFGHIJKLMONPQRSTUVWXYZ123456789";
            string passcode= "";
            ;

            Random rand = new Random();
            for(int i =0; i < 15; i ++){
                char choice = Choices[rand.Next(0, Choices.Length)];
                passcode += choice;
                HttpContext.Session.SetString("Password", "Passcode");
                ViewBag.Passcode = passcode;
                ViewBag.Count = Count2;
            }
            
            return View("Home");
        }
    }
}