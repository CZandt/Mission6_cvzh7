using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger, MovieFormContext mfc)
        {
            _logger = logger;
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
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            _blahContext.Add(ar);
            _blahContext.SaveChanges();

            return View("Confirmation", ar);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
