using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
{
    public class restauranterController : Controller
    {
        private restauranterContext _context;
 
        public restauranterController(restauranterContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/CreateReview")]
        public IActionResult CreateReview(Review review)
        {
           _context.Add(review);
           _context.SaveChanges();
           System.Console.WriteLine("Got this far");
           return Redirect("/allReviews");
        }
        [HttpGet]
        [Route("/allReviews")]
        public IActionResult allReviews()
        {
            
            List<Review> AllReviews = _context.Reviews.ToList();
            ViewBag.AllReviews = AllReviews;
            return View("ReviewPage");
        }
    }
}
