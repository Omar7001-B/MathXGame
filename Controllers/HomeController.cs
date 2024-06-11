using MathXGame.Data;
using MathXGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MathXGame.Controllers
{
    public class UserStatisticsViewModel
    {
        // User information
        public string UserName { get; set; }

        // General statistics
        public int TotalChallenges { get; set; }
        public int CompletedChallenges { get; set; }
        public int IncompleteChallenges { get; set; }
        public double BestPerformance { get; set; }
        public double AveragePerformance { get; set; }
        public double TotalTimeSpent { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageAccuracy { get; set; }
        public double AverageScore { get; set; }

        // Problem-specific statistics
        public int TotalProblemsSolved { get; set; }
        public int AdditionProblemsSolved { get; set; }
        public int SubtractionProblemsSolved { get; set; }
        public int MultiplicationProblemsSolved { get; set; }
        public int DivisionProblemsSolved { get; set; }
        public Dictionary<string, double> AverageTimePerProblemType { get; set; }

        // Challenge history
        public List<Challenge> ChallengeHistory { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }






        public IActionResult Index()
        {
            // Hello This is Masterrrr
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
            // Hello from Master
            // kasdfkl;sad;fjk;sj;dafkj;dsj;k
        }

        public IActionResult UserStatistics()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;


            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            _context.Entry(user).Collection(u => u.Challenges).Load();
            _context.Entry(user).Collection(u => u.Problems).Load();

            if(user.Challenges.Count == 0)
                return RedirectToAction("Index");

            UserStatisticsViewModel viewModel = new UserStatisticsViewModel
            {
                UserName = user.Username,
                // General statistics
                TotalChallenges = user.Challenges.Count,
                CompletedChallenges = user.Challenges.Count(c => c.FinishTime != DateTime.MinValue),
                IncompleteChallenges = user.Challenges.Count(c => c.FinishTime == DateTime.MinValue),
                BestPerformance = user.Challenges.Max(c => c.Score),
                AveragePerformance = Math.Round(user.Challenges.Average(c => c.Score), 2),
                TotalTimeSpent = Math.Round(user.Challenges.Sum(c => (c.FinishTime - c.StartTime).TotalHours), 2),
                AverageSpeed = Math.Round(user.Challenges.Average(c => c.Speed), 2),
                AverageAccuracy = Math.Round(user.Challenges.Average(c => c.Accuracy), 2),
                AverageScore = Math.Round(user.Challenges.Average(c => c.Score), 2),
                // Problem-specific statistics
                TotalProblemsSolved = user.Challenges.Sum(c => c.SolvedProblems),
                AdditionProblemsSolved = user.Challenges.SelectMany(c => c.Problems).Count(p => p.Expression.Contains("+")),
                SubtractionProblemsSolved = user.Challenges.SelectMany(c => c.Problems).Count(p => p.Expression.Contains("-")),
                MultiplicationProblemsSolved = user.Challenges.SelectMany(c => c.Problems).Count(p => p.Expression.Contains("*")),
                DivisionProblemsSolved = user.Challenges.SelectMany(c => c.Problems).Count(p => p.Expression.Contains("/")),
                AverageTimePerProblemType = CalculateAverageTimePerProblemType(user.Challenges),
                // Challenge history
                ChallengeHistory = user.Challenges.OrderByDescending(c => c.StartTime).ToList()
            };

            return View(viewModel);
        }

        private Dictionary<string, double> CalculateAverageTimePerProblemType(ICollection<Challenge> challenges)
        {
            // Logic to calculate average time per problem type
            var result = new Dictionary<string, double>
            {
                { "Addition", Math.Round(challenges.SelectMany(c => c.Problems).Where(p => p.Expression.Contains("+")).DefaultIfEmpty().Average(p => p?.TimeTaken ?? 0), 2) },
                { "Subtraction", Math.Round(challenges.SelectMany(c => c.Problems).Where(p => p.Expression.Contains("-")).DefaultIfEmpty().Average(p => p?.TimeTaken ?? 0), 2) },
                { "Multiplication", Math.Round(challenges.SelectMany(c => c.Problems).Where(p => p.Expression.Contains("*")).DefaultIfEmpty().Average(p => p?.TimeTaken ?? 0), 2) },
                { "Division", Math.Round(challenges.SelectMany(c => c.Problems).Where(p => p.Expression.Contains("/")).DefaultIfEmpty().Average(p => p?.TimeTaken ?? 0), 2) }
            };
            return result;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
