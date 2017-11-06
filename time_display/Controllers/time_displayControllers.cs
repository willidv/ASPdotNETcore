using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace time_display.Controllers
{
     public class time_displayController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
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