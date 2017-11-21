using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;


namespace WeddingPlanner.Controllers
{
    public class WeddingPlannerController : Controller
    {
        private WeddingPlannerContext _context;
 
        public WeddingPlannerController(WeddingPlannerContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.userError = TempData["UserError"];
            ViewBag.loginError = TempData["LoginError"];
            return View();
        }
        [HttpPost]
        [Route("/CreateUser")]
        public IActionResult CreateUser(WrapperVM theUser)
        {
            if(ModelState.IsValid)
            {
                User userEmailFound = _context.User.FirstOrDefault(user => user.Email == theUser.RegisterVM.Email);
                if(userEmailFound != null)
                {
                    ViewBag.emailExistsError = "Email already registered, please use a different email.";
                    return View("index");
                }
                else{
                User newUser = new User
                {
                    First_Name = theUser.RegisterVM.First_Name,
                    Last_Name = theUser.RegisterVM.Last_Name,
                    Email = theUser.RegisterVM.Email,
                    Password = theUser.RegisterVM.Password,
                };
                TryValidateModel(newUser);
                ViewBag.errors = ModelState.Values;
                _context.User.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("Current_User.UserId" , newUser.UserId);

                return Redirect("Weddings");
                }
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet]
        [Route("/LoginPage")]
        public IActionResult LoginPage()
        {
            return View("LoginPage");
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(WrapperVM model)
        {

            User EngagedUser = _context.User.SingleOrDefault(User =>User.Email == model.LogUser.LogEmail);

            if(model.LogUser.LogPassword == EngagedUser.Password)
            {
                HttpContext.Session.SetInt32("Current_User.UserId", EngagedUser.UserId);
                return Redirect("Weddings");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        [Route("/Weddings")]
        public IActionResult Weddings()
        {
            List<Wedding> AllWeddings = _context.Wedding.Include(Event=> Event.Guests).ToList();
            ViewBag.AllWeddings = AllWeddings;
            return View("AllWeddings");
        }

        [HttpGet]
        [Route("/AddWedding")]
        public IActionResult AddWedding()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("/CreateWedding")]
        public IActionResult CreateWedding(WrapperVM model)
        {
             if(ModelState.IsValid)
            {
                Wedding newWedding = new Wedding
                {
                    Wedder_One = model.Wedding.Wedder_One,
                    Wedder_Two = model.Wedding.Wedder_Two,
                    Date = model.Wedding.Date,
                    Address = model.Wedding.Address,
                    updated_at = DateTime.Now,
                    created_at = DateTime.Now
                   
                };
                TryValidateModel(newWedding);
                ViewBag.errors = ModelState.Values;
                _context.Add(newWedding);
                _context.SaveChanges();

                return RedirectToAction("Weddings");
            }
            else
            {
                return View("Add", model);
            }
        }

        [HttpGet]
        [Route("/Weddings/{WeddingId}/RSVP")]
        public IActionResult RSVP(int WeddingId)
        {
            Wedding thisWedding = _context.Wedding.SingleOrDefault(Event => Event.WeddingId == WeddingId);

            var thisGuest = _context.User.SingleOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Current_User.UserId"));

            

            Guest NewGuest = new Guest
            {
                Wedding = thisWedding,
                User = thisGuest,
                WeddingId = thisWedding.WeddingId,
                UserId = thisGuest.UserId,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };
            _context.Add(NewGuest);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        [HttpGet]
        [Route("/Weddings/{WeddingId}/GoToWedding")]
        public IActionResult GoToWedding(int WeddingId)
        {
            Wedding thisWedding = _context.Wedding.SingleOrDefault(Event => Event.WeddingId == WeddingId);

            List<Guest> WeddingGuests = _context.Guest.Where(Event=> Event.WeddingId == thisWedding.WeddingId).Include(user=> user.User).ToList();


            ViewBag.WeddingGuests = WeddingGuests;
            ViewBag.thisWedding = thisWedding;
            

            return View("Details");

        }

        [HttpGet]
        [Route ("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
 