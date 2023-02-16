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
            // Grabs the data for the movies from the database and passes it through to the view
            var movies = _blahContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Adds the categories to the view bag so it can still get passed through without the need for a view model
            ViewBag.Categories = _blahContext.Categories.ToList();

            // Grabs the movie with the id that was selected
            var movie = _blahContext.responses.Single(x => x.MovieID == id);

            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            //Updates the data in the database and then saves it to the database. Accidentially creates dupe record but that behavior
            // was seen in the videos
            _blahContext.Update(ar);
            _blahContext.SaveChanges();

            // redirects to the movie list
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Grabs the movie that was clicked on by its ID
            var movie = _blahContext.responses.Single(x => x.MovieID == id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            // Removes the record based of the idea then redirects back to the movie list
            _blahContext.responses.Remove(ar);
            _blahContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
