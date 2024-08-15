using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using MovieAPI.Data.Seeding;

namespace MovieAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Genre property conversion
            modelBuilder.Entity<Movie>()
                .Property(m => m.Genre)
                .HasConversion(
                    v => string.Join(',', v), // Convert List<string> to string for storage
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()); // Convert string to List<string> when retrieved

            // Apply the seed data
            MovieSeedData.Seed(modelBuilder);
        }
    }
}
