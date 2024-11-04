using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Core.Entities;

namespace Wba.MovieRating.Web.Data
{
    public class MovieDbContext : DbContext
    {
        //define the tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure the database tables
            base.OnModelCreating(modelBuilder);
        }
    }
}
