using MathXGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MathXGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Check if user is logged in
            var currentUser = HttpContext.Session.GetString("CurrentUser");
            if (!string.IsNullOrEmpty(currentUser))
            {
                // User is logged in, show the home page
                return View();
            }
            else
            {
                // User is not logged in, redirect to the login page
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
