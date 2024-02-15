using Microsoft.EntityFrameworkCore;

namespace Mission6_RyanTetro.Models
{
    public class MovieSubmitionContext : DbContext
    {
        public MovieSubmitionContext(DbContextOptions<MovieSubmitionContext> options) : base (options) 
        { 
        }

        public DbSet<Submition> Submitions { get; set; }
    }
}
