using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Core.Entities;

namespace Wba.MovieRating.Web.Data
{
    public class MovieDbContext : DbContext
    {
        //define the tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
      
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure the database tables
            //movie
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(200);
            //user
            modelBuilder.Entity<User>()
                .Property(u => u.Firstname)
                .IsRequired()
                .HasMaxLength(100);
            //actor
            modelBuilder.Entity<Actor>()
                .Property(a => a.Lastname)
                .IsRequired()
                .HasMaxLength(100);
            //director
            modelBuilder.Entity<Actor>()
                .Property(d => d.Lastname)
                .IsRequired()
                .HasMaxLength(100);
            //company
            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);
            //rating
            modelBuilder.Entity<Rating>()
                .Property(r => r.Score)
                .IsRequired();
            //configure triple primary key ActorMovies
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.ActorId, ma.MovieId, ma.Character });

            base.OnModelCreating(modelBuilder);
        }
    }
}
