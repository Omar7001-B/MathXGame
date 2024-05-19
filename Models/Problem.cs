using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MathXGame.Models
{
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProblemId { get; set; }
        public int ChallengeId { get; set; }
        public int UserId { get; set; }
        public string Expression { get; set; }
        public string RightAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool IsSolved { get; set; }
        public double TimeTaken { get; set; }
        public virtual Challenge Challenge { get; internal set; }
        public virtual User User { get; internal set;}
    }
}
