using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.Xml;
using Wba.MovieRating.Core.Entities;
using Wba.MovieRating.web.Models;
using Wba.MovieRating.Web.Areas.Admin.Models;
using Wba.MovieRating.Web.Areas.Admin.ViewModels;
using Wba.MovieRating.Web.Data;
using static System.Net.WebRequestMethods;

namespace Wba.MovieRating.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _movieDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoviesController(MovieDbContext movieDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _movieDbContext = movieDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        //shows a list of movies
        public async Task<IActionResult> Index()
        {
            //get the list of movies and put in viewmodel
            var moviesIndexViewModel = new MoviesIndexViewModel
            { 
                Movies = await _movieDbContext
                        .Movies
                        .Select(m => new MovieBaseViewModel 
                        {
                            Id = m.Id,
                            Value = m.Title,
                            Image = m.Image ?? "placeholder.svg",
                        }).ToListAsync()
            };
            return View(moviesIndexViewModel);
        }
        public async Task<IActionResult> Info(int id)
        {
            //get the movie
            var movie = await _movieDbContext
                .Movies
                .Include(m => m.Company)
                .Include(m => m.Actors)
                .ThenInclude(a => a.Actor)
                .Include(m => m.Directors)
                .AsSplitQuery()//to use separate queries
                .FirstOrDefaultAsync(m => m.Id == id);
            //check if null
            if (movie == null)
            {
                return NotFound();
            }
            //fill the model
            var movieInfoViewModel = new MoviesInfoViewModel
            {
                Id = movie.Id,
                Value = movie.Title,
                Company = new BaseViewModel
                {
                    Id = movie.Company.Id,
                    Value = movie.Company.Name,
                },
                Actors = movie.Actors.Select(a => new BaseViewModel
                {
                    Id = a.Actor.Id,
                    Value = $"{a.Actor.Firstname} {a.Actor.Lastname}"
                }),
                Directors = movie.Directors.Select(d => new BaseViewModel
                {
                    Id = d.Id,
                    Value = $"{d.Firstname} {d.Lastname}"
                }),
                Image = movie.Image ?? "placeholder.svg"

            };
            //pass to the view
            return View(movieInfoViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //load data in viewmodel
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(MoviesAddViewModel moviesAddViewModel)
        { 
            //check if movie exists
            if(await _movieDbContext.Movies
                .AnyAsync(m => m.Title.Equals(moviesAddViewModel.Title)))
            {
                //add custom error
                ModelState.AddModelError("Title", "Title exists!");
            }
            if(!ModelState.IsValid)
            {
                moviesAddViewModel.Companies = await _movieDbContext
                            .Companies.Select(c => new SelectListItem
                            {
                                Text = c.Name,
                                Value = c.Id.ToString()
                            }).ToListAsync();
                moviesAddViewModel.Actors = await _movieDbContext
                            .Actors.Select(a => new SelectListItem
                            {
                                Text = $"{a.Firstname} {a.Lastname}",
                                Value = a.Id.ToString()
                            }).ToListAsync();
                moviesAddViewModel.Directors = await _movieDbContext
                                   .Directors
                                   .Select(d => new CheckboxModel
                                   {
                                       Id = d.Id,
                                       Value = $"{d.Firstname} {d.Lastname}"
                                   }).ToListAsync();
                return View(moviesAddViewModel);
            }
            //create the movie
            //handle file upload
            var filename = "";
            if (moviesAddViewModel.Image != null)
            {
                //create unique filename
                filename = $"{Guid.NewGuid()}_{moviesAddViewModel.Image.FileName}";
                //create folder
                var folderToImages = Path.Combine(_webHostEnvironment.WebRootPath,
                    "images");
                if (!Directory.Exists(folderToImages))
                {
                    try
                    {
                        Directory.CreateDirectory(folderToImages);
                    }
                    catch (UnauthorizedAccessException unauthorizedAccessException)
                    {
                        Console.WriteLine(unauthorizedAccessException.Message);
                        return RedirectToAction("Error", "Home", new ErrorViewModel
                        {
                            RequestId = "testApp",
                        });
                    }
                }
                //create fullpath
                var fullpath = Path.Combine(folderToImages, filename);
                //copy to path
                try
                {
                    using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                    {
                        await moviesAddViewModel.Image.CopyToAsync(fileStream);
                    }
                }
                catch (IOException iOexception)
                {
                    Console.WriteLine(iOexception.Message);
                    return RedirectToAction("Error", "Home", new ErrorViewModel
                    {
                        RequestId = "testApp",
                    });
                }
            }
            //create the movie
            //get the selected directorIds
            var selectedDirectorIds = moviesAddViewModel.Directors
                .Where(d => d.IsChecked == true)
                .Select(d => d.Id);
            var movie = new Movie
            {
                Title = moviesAddViewModel.Title,
                ReleaseDate = moviesAddViewModel.ReleaseDate,
                Directors = await _movieDbContext
                            .Directors.Where(a => selectedDirectorIds
                            .Contains(a.Id)).ToListAsync(),

                CompanyId = moviesAddViewModel.CompanyId,
                Image = filename
            };
            //add the actors
            movie.Actors = new List<MovieActor>();
            foreach (var actor in moviesAddViewModel.ActorIds)
            {
                movie.Actors.Add(new MovieActor { MovieId = movie.Id, ActorId = actor, Character = "test" });
            }
            //add to change tracker
            _movieDbContext.Movies.Add(movie);

            //savechanges
            await _movieDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
