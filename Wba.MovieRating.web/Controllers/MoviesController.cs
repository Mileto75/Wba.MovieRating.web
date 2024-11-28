using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Security.Cryptography.Xml;
using Wba.MovieRating.Core.Entities;
using Wba.MovieRating.Web.Models;
using Wba.MovieRating.Web.Areas.Admin.Models;
using Wba.MovieRating.Web.Areas.Admin.ViewModels;
using Wba.MovieRating.Web.Data;
using Wba.MovieRating.Web.Services.Interfaces;
using Wba.MovieRating.Web.Services.Models;
using Wba.MovieRating.Web.ViewModels;
using static System.Net.WebRequestMethods;

namespace Wba.MovieRating.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _movieDbContext;

        public MoviesController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
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
    }
}

