using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace Dojo_Survey.Controllers
{
     public class Dojo_SurveyController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            return View("Home");
        }
        [HttpPost]
        [Route("method")]
        public IActionResult Method(string Name, string Location, string Language, string Comment)
        {
            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            return View("Results");
        }

    }
}