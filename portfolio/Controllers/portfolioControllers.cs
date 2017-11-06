using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace portfolio.Controllers
{
     public class portfolioController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            return View("Home");
        }
        
        [HttpGet]
        [Route("Projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }
    }
}