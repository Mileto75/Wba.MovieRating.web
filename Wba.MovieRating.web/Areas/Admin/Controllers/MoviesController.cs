using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Security.Cryptography.Xml;
using Wba.MovieRating.Core.Entities;
using Wba.MovieRating.web.Models;
using Wba.MovieRating.Web.Areas.Admin.Models;
using Wba.MovieRating.Web.Areas.Admin.ViewModels;
using Wba.MovieRating.Web.Data;
using Wba.MovieRating.Web.Services.Interfaces;
using Wba.MovieRating.Web.Services.Models;
using static System.Net.WebRequestMethods;

namespace Wba.MovieRating.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _movieDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFormBuilderService _formBuilderService;
        private readonly IFileService _fileService;

        public MoviesController(MovieDbContext movieDbContext, IWebHostEnvironment webHostEnvironment, IFormBuilderService formBuilderService, IFileService fileService)
        {
            _movieDbContext = movieDbContext;
            _webHostEnvironment = webHostEnvironment;
            _formBuilderService = formBuilderService;
            _fileService = fileService;
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
            var moviesAddViewModel = new MoviesAddViewModel
            {
                Companies = await _formBuilderService.GetCompaniesAsync(),
                Actors = await _formBuilderService.GetActorsAsync(),
                Directors = await _formBuilderService.GetDirectorsAsync(),
            };
            moviesAddViewModel.ReleaseDate = DateTime.Now;
            return View(moviesAddViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(MoviesAddViewModel moviesAddViewModel)
        {
            //check if movie exists
            if (await _movieDbContext.Movies
                .AnyAsync(m => m.Title.Equals(moviesAddViewModel.Title)))
            {
                //add custom error
                ModelState.AddModelError("Title", "Title exists!");
            }
            if (!ModelState.IsValid)
            {
                moviesAddViewModel.Companies = await _formBuilderService.GetCompaniesAsync();
                moviesAddViewModel.Actors = await _formBuilderService.GetActorsAsync();
                moviesAddViewModel.Directors = await _formBuilderService.GetDirectorsAsync();
                return View(moviesAddViewModel);
            }
            //create the movie
            //handle file upload
            var resultModel = new ResultModel();
            if (moviesAddViewModel.Image != null)
            {
                resultModel = await _fileService.StoreFileAsync(moviesAddViewModel.Image);
                if (!resultModel.IsSuccess)
                {
                    RedirectToAction("Error");
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
                Image = resultModel.Result,
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
            try
            {
                await _movieDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateExceptionn)
            {
                Console.Write(dbUpdateExceptionn.Message);
                return RedirectToAction(nameof(Index));
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //get the movie to edit
            var editMovie = await _movieDbContext
                .Movies
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editMovie == null)
            {
                return NotFound();
            }
            //create viewmodel
            var moviesEditViewModel = new MoviesEditViewModel
            {
                Title = editMovie.Title,
                ReleaseDate = editMovie.ReleaseDate,
                Actors = await _formBuilderService.GetActorsAsync(),
                //set the movie actors
                ActorIds = editMovie.Actors.Select(a => a.ActorId),
                Directors = await _formBuilderService.GetDirectorsAsync(),
                Companies = await _formBuilderService.GetCompaniesAsync(),
                //set the movie companyId
                CompanyId = editMovie.CompanyId,
                ImageFilename = editMovie.Image ?? "placeholder.svg"

            };
            //set the directors checkboxes
            //get the directo ids from editMovie
            //loop over Directors to set IsChecked
            //fill all te value + the dropdowns and checkboxes
            moviesEditViewModel.Directors
                .ForEach(md =>
                {
                    if (editMovie.Directors.Select(d => d.Id).Contains(md.Id))
                    {
                        md.IsChecked = true;
                    }
                });
            return View(moviesEditViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MoviesEditViewModel moviesEditViewModel)
        {
            //handles the edit form
            //validate
            if (!ModelState.IsValid)
            {
                moviesEditViewModel.Actors = await _formBuilderService.GetActorsAsync();
                moviesEditViewModel.Companies = await _formBuilderService.GetCompaniesAsync();
                return View(moviesEditViewModel);
            }
            //get the movie to edit
            var editMovie = await _movieDbContext
                .Movies
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .FirstOrDefaultAsync(m => m.Id == moviesEditViewModel.Id);
            //edit
            editMovie.Title = moviesEditViewModel.Title;
            editMovie.ReleaseDate = moviesEditViewModel.ReleaseDate;
            editMovie.CompanyId = moviesEditViewModel.CompanyId;
            editMovie.Actors.Clear();
            //get the selected directorIds from the checkbox list
            var selectedDirectorIds = moviesEditViewModel.Directors
                .Where(d => d.IsChecked).Select(d => d.Id);
            editMovie.Directors = await _movieDbContext
                            .Directors.Where(a => selectedDirectorIds
                            .Contains(a.Id)).ToListAsync();
            editMovie.Actors = new List<MovieActor>();
            foreach (var actor in moviesEditViewModel.ActorIds)
            {
                editMovie.Actors.Add(new MovieActor
                {
                    MovieId = editMovie.Id,
                    ActorId = actor,
                    Character = "test",
                });
            }
            //check for image upload
            if (moviesEditViewModel.Image != null)
            {
                var resultModel = new ResultModel();
                //check if movie has image
                if (!editMovie.Image.IsNullOrEmpty())
                {
                    //delete image on disk
                    var pathToImage = Path.Combine(_webHostEnvironment.WebRootPath,
                        "images", editMovie.Image);
                    if (_fileService.DeleteFile(pathToImage))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                //save new file
                resultModel = await _fileService.StoreFileAsync(moviesEditViewModel.Image);
                if (!resultModel.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                editMovie.Image = resultModel.Result;
            }
            //save to database
            try
            {
                await _movieDbContext.SaveChangesAsync();
                //set success message here
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateExceptionn)
            {
                Console.Write(dbUpdateExceptionn.Message);
                //set success message here
                return RedirectToAction(nameof(Index));
                //set error message here
            }
        }
    }
}

