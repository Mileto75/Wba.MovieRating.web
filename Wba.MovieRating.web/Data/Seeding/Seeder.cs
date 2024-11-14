using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Core.Entities;

namespace Wba.MovieRating.Web.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Company
            var companies = new Company[] 
            {
                new Company{Id = 1, Name = "Miramax", Created = DateTime.Now },
                new Company{Id = 2, Name = "Weinstein", Created = DateTime.Now },
            };
            //Directors
            var directors = new Director[] 
            {
                new Director{Id = 1, Firstname = "Bob", Lastname = "Saget",Created = DateTime.Now},
                new Director{Id = 2, Firstname = "Walter", Lastname = "Capiau",Created = DateTime.Now},
            };
            var actors = new Actor[]
            {
                new Actor{Id = 1, Firstname = "Al", Lastname = "Pacino",Created = DateTime.Now},
                new Actor{Id = 2, Firstname = "Robert", Lastname = "De Niro",Created = DateTime.Now},
                new Actor{Id = 3, Firstname = "Kate", Lastname = "Winslet",Created = DateTime.Now},
            };
            var users = new User[]
            {
                new User{Id = 1, Firstname = "Bart", Lastname = "Soete",Created = DateTime.Now},
                new User{Id = 2, Firstname = "Tibo", Lastname = "Van Craenenbroeck",Created = DateTime.Now},
                new User{Id = 3, Firstname = "Tine", Lastname = "Baelde",Created = DateTime.Now},
            };
            var movies = new Movie[] 
            {
                new Movie{Id = 1,Title = "Deadpool",CompanyId = 1,Created = DateTime.Now,ReleaseDate = DateTime.Parse("2018-08-03")},
                new Movie{Id = 2,Title = "The Suicide squad",CompanyId = 1,Created = DateTime.Now,ReleaseDate = DateTime.Parse("2018-12-23")},
                new Movie{Id = 3,Title = "Venom",CompanyId = 2,Created = DateTime.Now,ReleaseDate = DateTime.Parse("2020-12-23")},
                new Movie{Id = 4,Title = "Titanic",CompanyId = 2,Created = DateTime.Now,ReleaseDate = DateTime.Parse("1999-11-03")},
            };
            //MoviesActors
            var moviesActors = new MovieActor[]
            {
                new MovieActor{ActorId = 1, MovieId = 1,Character = "Deadpool"  },
                new MovieActor{ActorId = 1, MovieId = 2, Character = "The weasel"  },
                new MovieActor{ActorId = 2, MovieId = 3, Character = "Venom"  },
                new MovieActor{ActorId = 2, MovieId = 4, Character = "Die snelle" },
                new MovieActor{ActorId = 3, MovieId = 1, Character = "Colossus"  },
                new MovieActor{ActorId = 3, MovieId = 2,Character = "TDK"  },
                new MovieActor{ActorId = 1, MovieId = 3, Character = "The cop"  },
                new MovieActor{ActorId = 1, MovieId = 4,Character = "Dien blonten"  },
            };
            //DirectorMovies
            var movieDirectors = new[]
            {
                new {DirectorsId = 1, MoviesId = 1 },
                new {DirectorsId = 2, MoviesId = 2 },
                new {DirectorsId = 1, MoviesId = 3 },
                new {DirectorsId = 2, MoviesId = 4 },
            };
            //ratings
            var ratings = new Rating[]
            {
                new Rating{Id = 1,Score = 4,MovieId = 1,UserId = 1,Created = DateTime.Now,Review = "Great movie!"},
                new Rating{Id = 2,Score = 5,MovieId = 2,UserId = 1,Created = DateTime.Now,Review = "Top!!"},
                new Rating{Id = 3,Score = 2,MovieId = 3,UserId = 1,Created = DateTime.Now,Review = "Suckt ongelooflijk!"},
                new Rating{Id = 4,Score = 2,MovieId = 4,UserId = 1,Created = DateTime.Now,Review = "Machtig!!"},
            };
            //hasdata methods
            //companies
            modelBuilder.Entity<Company>().HasData(companies);
            //directors
            modelBuilder.Entity<Director>().HasData(directors);
            //users
            modelBuilder.Entity<User>().HasData(users);
            //actors
            modelBuilder.Entity<Actor>().HasData(actors);
            //movie
            modelBuilder.Entity<Movie>().HasData(movies);
            //ratings
            modelBuilder.Entity<Rating>().HasData(ratings);
            //movieActors
            modelBuilder.Entity<MovieActor>().HasData(moviesActors);
            //movieDirectors
            modelBuilder.Entity($"{nameof(Director)}{nameof(Movie)}").HasData(movieDirectors);

        }
    }
}
