using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace firstASP.Controllers
{
     public class HelloController : Controller
    {
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
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