using MathXGame.Data;
using MathXGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace MathXGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context) { _context = context; }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Find the user in the database based on the provided username
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            // Check if the user exists and if the password matches
            if (user != null && user.Password == password)
            {
                // Authentication successful, store user information in session
                HttpContext.Session.SetString("CurrentUser", user.Username);
                HttpContext.Session.SetInt32("UserId", user.Id);

                // Redirect to home page or another desired destination
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Authentication failed, display error message or redirect to login page
                ModelState.AddModelError("LoginFailed", "Invalid username or password.");
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {
            // Check if the username is already taken
            if (_context.Users.Any(u => u.Username == username))
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return View();
            }

            // Create a new user and add it to the database
            var newUser = new User
            {
                Username = username,
                Password = password, // Hash and salt the password before saving it in production
                Email = email
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            // Redirect to login page after successful registration
            return RedirectToAction("Login");
        }

        // make me a logout action
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Login");
        }


        // Handle form submission
        [HttpPost]
        public IActionResult Settings(User model)
        {
            _context.Users.Update(model);
            _context.SaveChanges();
            return View(model);
        }

         // Display the edit form
        [HttpGet]
        public IActionResult Settings()
        {
            var model = _context.Users.Find(HttpContext.Session.GetInt32("UserId"));
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
