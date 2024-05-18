using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MathXGame.Controllers
{
    public class Challenge
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; } // Action name corresponding to the challenge
    }

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
    public class ChallengesController : Controller
    {
        // GET: /Challenges
        public IActionResult Index()
        {
            var challenges = new List<Challenge>
            {
                new Challenge { Name = "Keyboard Input Challenge", Description = "Enter answers using keyboard input", Action = "KeyboardInputChallenge" },
                new Challenge { Name = "Multiple Choice Challenge", Description = "Select answers from multiple choices", Action = "MultipleChoiceChallenge" },
                new Challenge { Name = "Missing Operator Challenge", Description = "Identify missing operators in equations", Action = "MissingOperatorChallenge" },
                new Challenge { Name = "Word Problem Challenge", Description = "Solve word problems by typing answers in words", Action = "WordProblemChallenge" },
                new Challenge { Name = "Math Memory Challenge", Description = "Memorize and solve math problems", Action = "MathMemoryChallenge" },
                new Challenge { Name = "Number Placement Challenge", Description = "Place numbers correctly in equations", Action = "NumberPlacementChallenge" },
                new Challenge { Name = "Comparison Challenge", Description = "Compare two expressions with <, >, or =", Action = "ComparisonChallenge" },
                new Challenge { Name = "Solve for X Challenge", Description = "Solve for X in algebraic equations", Action = "SolveForXChallenge" },
                new Challenge { Name = "True/False Challenge", Description = "Determine if math statements are true or false", Action = "TrueFalseChallenge" },
                new Challenge { Name = "Number Combination Challenge", Description = "Combine numbers to reach a target sum", Action = "NumberCombinationChallenge" }
            };

            return View(challenges);
        }

        [HttpPost]
        public ActionResult ProcessChallengeData([FromBody] ChallengeDataViewModel data)
        {
            // Process the received data
            // For demonstration purposes, let's assume you want to pass the data to a view
            return Content("Challenge data processed successfully");
            return View("FinishedChallenge", data);
        }

        public ActionResult FinishedChallenge(ChallengeDataViewModel data)
        {
            // Pass the data to the view
            return View(data);
        }
    



        // POST: /Challenges/Start
        [HttpPost]
        public IActionResult Start(ChallengeConfiguration configuration)
        {
            // Process the challenge configuration submitted by the user
            // You can perform any necessary logic here, such as starting the challenge with the specified settings

            // For demonstration purposes, we'll just return a message indicating that the challenge has started
            string message = $"Starting {configuration.SelectedChallenge} challenge with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.NumberOfQuestions}";

            return Content(message);
        }

        // Action method for starting the Keyboard Input Challenge, that takes a configuration object as a parameter
        [HttpPost]
        public IActionResult KeyboardInputChallenge(ChallengeConfiguration configuration)
        {
            // Process the configuration and start the Keyboard Input Challenge
            string message = $"Starting Keyboard Input Challenge with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.NumberOfQuestions}";


            return View(configuration);
        }

        // Action method for starting the Multiple Choice Challenge, that takes a configuration object as a parameter
        [HttpPost]
        public IActionResult MultipleChoiceChallenge(ChallengeConfiguration configuration)
        {
            // Process the configuration and start the Multiple Choice Challenge
            string message = $"Starting Multiple Choice Challenge with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.NumberOfQuestions}";

            return Content(message);
        }

        // Action method for starting the Missing Operator Challenge, that takes a configuration object as a parameter
        [HttpPost]
        public IActionResult MissingOperatorChallenge(ChallengeConfiguration configuration)
        {
            // Process the configuration and start the Missing Operator Challenge
            string message = $"Starting Missing Operator Challenge with the following settings: ";
            message += $"Number Range: {configuration.MinNumber}-{configuration.MaxNumber}, ";
            message += $"Timer (Seconds): {configuration.TimerInSeconds}, ";
            message += $"Operations: {(configuration.Addition ? "Addition" : "")}{(configuration.Subtraction ? ", Subtraction" : "")}{(configuration.Multiplication ? ", Multiplication" : "")}{(configuration.Division ? ", Division" : "")}, ";
            message += $"Number of Questions: {configuration.NumberOfQuestions}";

            return Content(message);
        }

    }
}
