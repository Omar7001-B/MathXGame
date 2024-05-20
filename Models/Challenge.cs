using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MathXGame.Models
{
    public class Challenge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallengeId { get; set; }
        public int UserId { get; set; }

        // Challenge Configuration
        public string SelectedChallenge { get; set; }
        public int TotalProblems { get; set; }
        public int TimerInSeconds { get; set; }

        // Range of Numbers
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }

        // Operations
        public bool Addition { get; set; }
        public bool Subtraction { get; set; }
        public bool Multiplication { get; set; }
        public bool Division { get; set; }

        // Challenge Results
        public int SolvedProblems { get; set; }
        public int Misses { get; set; }
        public double Speed { get; set; }
        public double Accuracy { get; set; }
        public double Score { get; set; }  // New property for the score
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public virtual User? User { get; internal set; }
        public virtual List<Problem>? Problems { get; set; }

        // Method to calculate speed, accuracy, and score
        public void CalculateStatistics()
        {
            if (Problems != null && Problems.Count > 0)
            {
                Speed = Math.Round(Problems.Average(p => p.TimeTaken), 2);  // Calculate average speed
                SolvedProblems = Problems.Count(p => p.IsSolved);
                Misses = Problems.Count(p => !p.IsSolved);
                Accuracy = Math.Round((double)SolvedProblems / (SolvedProblems + Misses) * 100, 2);  // Calculate accuracy
            }

            double problemScore = (double)SolvedProblems / TotalProblems;
            double accuracyScore = Accuracy / 100;
            double speedScore = (TimerInSeconds > 0) ? (TimerInSeconds - Speed) / TimerInSeconds : 0;

            // Weighted score calculation (example weights: 50% problems, 30% accuracy, 20% speed)
            Score = (problemScore * 0.5) + (accuracyScore * 0.3) + (speedScore * 0.2);
            Score *= 100; // Normalize score to be out of 100
            Score = Math.Round(Score, 2);
        }
    }
}
