using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weddingPlan.Models;


namespace weddingPlan.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        private weddingContext _context;
        public HomeController(weddingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("registerAccount")]
        public IActionResult registerAccount(UserReg newUser)
        {
            User currentUser = _context.Users.SingleOrDefault(u => u.email == newUser.email);
            if (currentUser != null)
            {
                ViewBag.Error = "Email already in use";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    User user = new User()
                    {
                        firstName = newUser.firstName,
                        lastName = newUser.lastName,
                        email = newUser.email,
                        password = newUser.password,
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("name", currentUser.firstName);
                    HttpContext.Session.SetInt32("id", currentUser.userId);
                    return RedirectToAction("Dashboard", "Wedding");
                }
            }
            return View("Register");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult login(string email, string password)
        {
            User check = _context.Users.SingleOrDefault(user => user.email == email && user.password == password);
            if (check.email == email && check.password == password)
            {
                HttpContext.Session.SetInt32("id", check.userId);
                HttpContext.Session.SetString("name", check.firstName);
                return RedirectToAction("Dashboard", "Wedding");
            }
            return RedirectToAction("index");
        }
    }
}
