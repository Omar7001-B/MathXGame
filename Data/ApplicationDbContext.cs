using MathXGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MathXGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
