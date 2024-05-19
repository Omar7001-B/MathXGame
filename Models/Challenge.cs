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
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public virtual User? User { get; internal set; }
        public virtual List<Problem>? Problems { get; set; }
    }
}
