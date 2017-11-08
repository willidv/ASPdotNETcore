using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Quoting_Dojo.Connectors;




namespace Quoting_Dojo.Controllers
{
    public class Quoting_DojoController : Controller
    {
        private DbConnector cnx;

        public Quoting_DojoController(){
           cnx = new DbConnector();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [Route("/addQuote")]
        public IActionResult addQuote(string Quote, string Author)
        {
            var updated_at = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            var created_at = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string query = $"Insert Into quotes(Quote, Author, updated_at, created_at) VALUES ('{Quote}', '{Author}', '{updated_at}', '{created_at}')";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/allQuotes")]
        public IActionResult allQuotes()
        {
            string query = "Select * from quotes";
            var allQuotes = DbConnector.Query(query);
            ViewBag.allQuotes = allQuotes;
            return View("Quotes");
        }
    }
}
