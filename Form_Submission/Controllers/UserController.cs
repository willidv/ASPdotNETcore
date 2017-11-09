using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Form_Submission.Models;
using Newtonsoft.Json;
using Form_Submission.Factory;

namespace Form_Submission.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory UserFactory;
        private readonly DbConnector _dbConnector;

        public UserController(DbConnector connect)
        {
            UserFactory = new UserFactory();
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult CreateUser(User newUser)
        {
            if (TryValidateModel(newUser))
            {
                UserFactory.Add(newUser);
                return RedirectToAction("Success");
            }
            else
            {
                System.Console.WriteLine("The price is wrong, b****");
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }
        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            IEnumerable<User> factoryResult = UserFactory.FindAll();
            ViewBag.User = factoryResult;
            return View();
        }
    }
}
