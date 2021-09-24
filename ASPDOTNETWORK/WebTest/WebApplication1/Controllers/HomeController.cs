using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /* This is for the index page. Since no page/view is given, it's assuemd the index page should be served. */
        public IActionResult Index()
        {
            return View();
        }
        /* If a person clicks on the 'Privacy' Link, it should call the Controller to serve the Privacy Page */
        public IActionResult Privacy()
        {
            return View();
        }

        /* If there is an error, it's usually from the User clicking a link that dosen't exist */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
