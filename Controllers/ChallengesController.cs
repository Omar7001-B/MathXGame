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

    /*
    public class ChallengeConfiguration
    {
        public string SelectedChallenge { get; set; }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public int TimerInSeconds { get; set; }
        public bool Addition { get; set; }
        public bool Subtraction { get; set; }
        public bool Multiplication { get; set; }
        public bool Division { get; set; }
        public int NumberOfQuestions { get; set; }
    }

    public class ChallengeDataViewModel
    {
        public int TotalProblems { get; set; }
        public int SolvedProblems { get; set; }
        public int Misses { get; set; }
        public double Speed { get; set; }
        public double Accuracy { get; set; }
        public DateTime StartTime { get; set; }
        public ExpressionViewModel[] Expressions { get; set; }
    }

    public class ExpressionViewModel
    {
        public string Expression { get; set; }
        public string RightAnswer { get; set; }
        public string YourAnswer { get; set; }
        public bool Correct { get; set; }
        public double TimeTaken { get; set; }
    }
    */
    public class ChallengesController : Controller
    {
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

        //[HttpPost]
        public ActionResult ProcessChallengeData(Challenge data, string problemsJson)
        {
            data.Problems = JsonConvert.DeserializeObject<List<Problem>>(problemsJson);
            // Process the received data
            // For demonstration purposes, let's assume you want to pass the data to a viewList<Problem>?
            return Content("ChallengeSelectItem data processed successfully");
        }

        public ActionResult FinishedChallenge(Challenge data)
        {
            // Pass the data to the view
            return View(data);
        }
    



        // POST: /Challenges/Start
        [HttpPost]
        public IActionResult Start(Challenge configuration)
        {
            // Process the challenge configuration submitted by the user
            // You can perform any necessary logic here, such as starting the challenge with the specified settings

            // For demonstration purposes, we'll just return a message indicating that the challenge has started
            string message = $"Starting {configuration.SelectedChallenge} challenge with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.TotalProblems}";

            return Content(message);
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

        // Action method for starting the Multiple Choice ChallengeSelectItem, that takes a configuration object as a parameter
        [HttpPost]
        public IActionResult MultipleChoiceChallenge(Challenge configuration)
        {
            // Process the configuration and start the Multiple Choice ChallengeSelectItem
            string message = $"Starting Multiple Choice ChallengeSelectItem with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.TotalProblems}";

            return Content(message);
        }

        // Action method for starting the Missing Operator ChallengeSelectItem, that takes a configuration object as a parameter
        [HttpPost]
        public IActionResult MissingOperatorChallenge(Challenge configuration)
        {
            // Process the configuration and start the Missing Operator ChallengeSelectItem
            string message = $"Starting Missing Operator ChallengeSelectItem with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.TotalProblems}";

            return Content(message);
        }

    }
}
