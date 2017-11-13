using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using logreg.Models;
using Newtonsoft.Json;
using logreg.Factory;

namespace logreg.Controllers
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
        public IActionResult CreateUser(User RegUser)
        {
            
            if (TryValidateModel(RegUser))
            {
                UserFactory.Add(RegUser);
                return RedirectToAction("Success");
            }
            else
            {

                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }
        [HttpPost]
        [Route("/Login")]
        public IActionResult LoginUser(LoginVM LogUser)
        {
            if (TryValidateModel(LogUser))
            {
                UserFactory.Find(LogUser);
                return RedirectToAction("Success");
            }
            else
            {
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
