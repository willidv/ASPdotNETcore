using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using dojoDiner.Models;
using Newtonsoft.Json;
using dojoDiner.Factory;

namespace dojoDiner.Controllers
{
    public class HomeController : Controller
    {
        private readonly MenuItemFactory menuItemFactory;
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            menuItemFactory = new MenuItemFactory();
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
        public IActionResult CreateProduct(MenuItem newItem)
        {
            if(TryValidateModel(newItem))
            {
                // do something if the model is good
                // System.Console.WriteLine("Model is valid");

                menuItemFactory.Add(newItem);

                // string query = $"INSERT INTO MENUITEM (NAME, PRICE, DESCRIPTION, ISVEGGO, ISAVAILABLE, CATEGORY) VALUES ('{newItem.Name}', {newItem.Price}, '{newItem.Description}', {newItem.isVeggo}, {newItem.isAvailable}, '{newItem.Category}')";
                
                // _dbConnector.Execute(query);

                // // SERIALIZE the object to a string to make it passable through TempData
                // string stringVersionOfNewItem = JsonConvert.SerializeObject(newItem);
                // TempData["NEW_ITEM"] = stringVersionOfNewItem;

                // No errors, no data to ferry, no problem with view bag.
                return RedirectToAction("Success");
            }
            else
            {
                // do something if the model is no good
                System.Console.WriteLine("The price is wrong, b****");

                // So the view can access the errors
                ViewBag.errors = ModelState.Values;
                
                // When we have erros we should NOT redirect... 
                // we should instead render the previous view to show errors 
                // and to allow the user to correct them.
                return View("Index");
            }
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {

            IEnumerable<MenuItem> factoryResult = menuItemFactory.FindAll();
            ViewBag.menuItems = factoryResult;

            // string query = "SELECT * FROM MENUITEM";
            // List<Dictionary<string, object>> result = _dbConnector.Query(query);
            // ViewBag.allItems = result;

            // string itemString = TempData["NEW_ITEM"].ToString();
            // MenuItem newItem = JsonConvert.DeserializeObject<MenuItem>(itemString);
            // ViewBag.newItem = newItem;

            return View();
        }
    }
}
