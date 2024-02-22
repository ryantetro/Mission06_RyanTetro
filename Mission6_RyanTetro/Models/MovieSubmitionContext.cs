using Microsoft.EntityFrameworkCore;
using Mission06_RyanTetro.Models;

namespace Mission6_RyanTetro.Models
{
    public class MovieSubmitionContext : DbContext
    {
        public MovieSubmitionContext(DbContextOptions<MovieSubmitionContext> options) : base (options) 
        { 
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
