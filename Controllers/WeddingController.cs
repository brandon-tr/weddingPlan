using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weddingPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace weddingPlan.Controllers
{
    public class WeddingController : Controller
    {
        private weddingContext _context;
        public WeddingController(weddingContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            List<Wedding> allWeddings = _context.Weddings.Include(w => w.guests).ToList();
            // System.Console.WriteLine(allWeddings[0].guests[0].user.Weddings);
            ViewBag.Id = HttpContext.Session.GetInt32("id");
            ViewBag.AllWeddings = allWeddings;
            return View();
        }

        [HttpGet]
        [Route("wedding")]
        public IActionResult wedding()
        {
            return View();
        }

        [HttpPost]
        [Route("addWedding")]
        public IActionResult addWedding(WeddingReg newWedding)
        {
            if(newWedding.date < DateTime.Now){
                    ViewBag.Error = "Date has to be set in the future";
                }else{
            if (ModelState.IsValid)
            {
                Wedding wedding = new Wedding()
                {
                    date = newWedding.date,
                    wedderOne = newWedding.wedderOne,
                    wedderTwo = newWedding.wedderTwo,
                    createdAt = DateTime.Now,
                    address = newWedding.address,
                    creatorId = (int)HttpContext.Session.GetInt32("id"),
                };
                _context.Weddings.Add(wedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
                }
            return View("wedding");
        }
        [HttpGet]
        [Route("RSVP/{weddingId}")]
        public IActionResult Rsvp(int weddingId)
        {
            Guest newGuest = new Guest()
            {
                userId = (int)HttpContext.Session.GetInt32("id"),
                weddingId = weddingId
            };
            _context.Add(newGuest);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("UNRSVP/{weddingId}/{userID}")]
        public IActionResult UnRsvp(int weddingId, int userId)
        {
            Guest RetrievedUser = _context.Guests.SingleOrDefault(t => t.weddingId == weddingId && t.userId == userId);
            _context.Guests.Remove(RetrievedUser);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("deleteWedding/{weddingId}")]
        public IActionResult deleteWedding(int weddingId)
        {
            Wedding RetrievedUser = _context.Weddings.SingleOrDefault(t => t.weddingId == weddingId);
            _context.Weddings.Remove(RetrievedUser);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("wedding/{weddingId}")]
        public IActionResult weddingPage(int weddingId)
        {
            var wedding = _context.Weddings.Where(c => c.weddingId == weddingId).Include(t => t.guests).ThenInclude(x => x.user).ToList();
            ViewBag.AllGuest = wedding;
            return View();
        }
    }
}