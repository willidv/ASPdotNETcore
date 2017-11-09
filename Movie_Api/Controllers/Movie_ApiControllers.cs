using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Movie_Api.Controllers
{
    public class Movie_ApiController : Controller
    {
        private readonly DbConnector _dbConnector;

        public Movie_ApiController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpPost]
        [Route("results")]
        public IActionResult QueryMovie(string title)
        {
            var movieInfo = new Dictionary<string, object>();
            WebRequest.GetMovieDataAsync(title, ApiResponse =>
        {
            movieInfo = ApiResponse;
        }
    ).Wait();
            TempData["movieInfo"] = movieInfo;

            return RedirectToAction("Index");
            // Other code
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
