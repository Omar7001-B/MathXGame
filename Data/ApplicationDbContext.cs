using MathXGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MathXGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Problem> Problems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationships

            // One-to-Many relationship between User and ChallengeSelectItem
            modelBuilder.Entity<Challenge>()
                .HasOne(c => c.User)
                .WithMany(u => u.Challenges)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // One-to-Many relationship between ChallengeSelectItem and Problem
            modelBuilder.Entity<Problem>()
                .HasOne(p => p.Challenge)
                .WithMany(c => c.Problems)
                .HasForeignKey(p => p.ChallengeId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a challenge is deleted
        }
    }
}
