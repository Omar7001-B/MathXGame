using MathXGame.Data;
using MathXGame.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MathXGame.Controllers
{
    public class ChallengeSelectItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; } // Action name corresponding to the challenge
    }
    public class ChallengesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ChallengesController(ApplicationDbContext context) { _context = context; }
        // GET: /Challenges
        public IActionResult Index()
        {
            var challenges = new List<ChallengeSelectItem>
            {
                new ChallengeSelectItem { Name = "Keyboard Input Challenge", Description = "Enter answers using keyboard input", Action = "KeyboardInputChallenge" },
                new ChallengeSelectItem { Name = "Multiple Choice Challenge", Description = "Select answers from multiple choices", Action = "MultipleChoiceChallenge" },
                new ChallengeSelectItem { Name = "Missing Operator Challenge", Description = "Identify missing operators in equations", Action = "MissingOperatorChallenge" },
                new ChallengeSelectItem { Name = "Word Problem Challenge", Description = "Solve word problems by typing answers in words", Action = "WordProblemChallenge" },
                new ChallengeSelectItem { Name = "Math Memory Challenge", Description = "Memorize and solve math problems", Action = "MathMemoryChallenge" },
                new ChallengeSelectItem { Name = "Number Placement Challenge", Description = "Place numbers correctly in equations", Action = "NumberPlacementChallenge" },
                new ChallengeSelectItem { Name = "Comparison Challenge", Description = "Compare two expressions with <, >, or =", Action = "ComparisonChallenge" },
                new ChallengeSelectItem { Name = "Solve for X Challenge", Description = "Solve for X in algebraic equations", Action = "SolveForXChallenge" },
                new ChallengeSelectItem { Name = "True/False Challenge", Description = "Determine if math statements are true or false", Action = "TrueFalseChallenge" },
                new ChallengeSelectItem { Name = "Number Combination Challenge", Description = "Combine numbers to reach a target sum", Action = "NumberCombinationChallenge" }
            };

            return View(challenges);
        }

        public IActionResult ErrorMessage(string msg)
        {
            return View("ErrorMessage", new {ErrorMessage = msg});
        }

        //[HttpPost]
        public ActionResult ProcessChallengeData(Challenge data, string problemsJson)
        {
            if (data == null || string.IsNullOrEmpty(problemsJson))
                return RedirectToAction("ErrorMessage", new { msg = "Invalid data received!" });

            if (data.SolvedProblems + data.Misses == 0)
                return RedirectToAction("ErrorMessage", new { msg = "No problems found in the challenge" });

            if (data.ChallengeId == 0)
            {
                data.UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
                data.ChallengeId = 0;

                data.StartTime = data.StartTime.ToLocalTime();
                data.FinishTime = data.FinishTime.ToLocalTime();

                _context.Challenges.Add(data);
                _context.SaveChanges();
                data.Problems = JsonConvert.DeserializeObject<List<Problem>>(problemsJson);


                for (int i = 0; i < data.Problems.Count; i++)
                {
                    data.Problems[i].ChallengeId = data.ChallengeId;
                    data.Problems[i].UserId = data.UserId;
                }

                _context.Problems.AddRange(data.Problems);
                data.CalculateStatistics();
                _context.SaveChanges();
            }
            else
            {
                // update the challenge
                // load the problems 
                var challenge = _context.Challenges.Find(data.ChallengeId);
                data.Problems = JsonConvert.DeserializeObject<List<Problem>>(problemsJson);

                data.StartTime = data.StartTime.ToLocalTime();
                data.FinishTime = data.FinishTime.ToLocalTime();

                if (data.Problems != null)
                foreach (var problem in data.Problems)
                {
                    var dbProblem = _context.Problems.Find(problem.ProblemId);
                    dbProblem.UserAnswer = problem.UserAnswer;
                    dbProblem.IsSolved = problem.IsSolved;
                    dbProblem.TimeTaken = problem.TimeTaken;
                    _context.Problems.Update(dbProblem);
                }
                _context.Challenges.Update(challenge);
                _context.SaveChanges();

                challenge.CalculateStatistics();

                _context.Challenges.Update(challenge);
                _context.SaveChanges();
            }

            return RedirectToAction("ViewChallenge", new { id = data.ChallengeId });
        }

        public IActionResult ViewChallenge(int id)
        {
            var challenge = _context.Challenges.Find(id);
            _context.Entry(challenge).Collection(c => c.Problems).Load();
            _context.Entry(challenge).Reference(c => c.User).Load();
            challenge.CalculateStatistics();

            if (challenge == null)
                return Content("ChallengeSelectItem not found");
            return View(challenge);
        }

        public IActionResult ReviewChallenge(int challengeId, string reviewType)
        {
            var challenge = _context.Challenges.Find(challengeId);
            if (challenge == null)
                return Content("ChallengeSelectItem not found");
            // _context.Entry(challenge).Collection(c => c.Problems).Load();
            // _context.Entry(challenge).Reference(c => c.User).Load();

            // load the problems
            challenge.Problems = _context.Problems.Where(p => p.ChallengeId == challengeId).ToList();
            foreach (var problem in challenge.Problems)
            {
                problem.Challenge = null;
                problem.User = null;
            }


            double speed = challenge.Speed;
            if (reviewType  == "Incorrect")
                challenge.Problems = challenge.Problems.Where(p => p.UserAnswer != p.RightAnswer).ToList();
            else if(reviewType == "Slow")
                challenge.Problems = challenge.Problems.Where(p => p.TimeTaken > speed).ToList();
            else if(reviewType == "Both")
                challenge.Problems = challenge.Problems.Where(p => p.UserAnswer != p.RightAnswer || p.TimeTaken > speed).ToList();
            else if(reviewType == "All")
                challenge.Problems = challenge.Problems.ToList();

            // Shuffle the problems
            challenge.Problems = challenge.Problems.OrderBy(p => Guid.NewGuid()).ToList();

            string viewName = challenge.SelectedChallenge.Replace(" ", "");
            return View(viewName, challenge);
        }

        public ActionResult FinishedChallenge(Challenge data)
        {
            // Pass the data to the view
            return View(data);
        }


        // Action method for starting the Keyboard Input ChallengeSelectItem, that takes a configuration object as a parameter
        [HttpPost]
        public IActionResult KeyboardInputChallenge(Challenge configuration)
        {
            // Process the configuration and start the Keyboard Input ChallengeSelectItem
            string message = $"Starting Keyboard Input ChallengeSelectItem with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.TotalProblems}";


            return View(configuration);
        }

        [HttpPost]
        public IActionResult MultipleChoiceChallenge(Challenge configuration)
        {
            string message = $"Starting Multiple Choice ChallengeSelectItem with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.TotalProblems}";

            return View(configuration);
        }

    }
}
