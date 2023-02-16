using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_cvzh7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_cvzh7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieFormContext _blahContext { get; set; }

        public HomeController(MovieFormContext mfc)
        {
            _blahContext = mfc;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Podcasts view that we may just want to make  static hyperlink
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _blahContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid) // Checks if the submitted form is valid and meets all the data validations
            {
                _blahContext.Add(ar);
                _blahContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else // if not returns them to the form with the errors
            {
                ViewBag.Categories = _blahContext.Categories.ToList();
                return View(ar);
            }

        }

        public IActionResult MovieList()
        {
            var movies = _blahContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _blahContext.Categories.ToList();

            var movie = _blahContext.responses.Single(x => x.MovieID == id);

            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        { 
            _blahContext.Update(ar);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _blahContext.responses.Single(x => x.MovieID == id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _blahContext.responses.Remove(ar);
            _blahContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
