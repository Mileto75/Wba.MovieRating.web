using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Web.Areas.Admin.Models;
using Wba.MovieRating.Web.Data;
using Wba.MovieRating.Web.Services.Interfaces;

namespace Wba.MovieRating.Web.Services
{
    public class FormBuilderService : IFormBuilderService
    {
        private readonly MovieDbContext _movieDbContext;

        public FormBuilderService(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<IEnumerable<SelectListItem>> GetActorsAsync()
        {
            return await _movieDbContext
                            .Actors.Select(a => new SelectListItem
                            {
                                Text = $"{a.Firstname} {a.Lastname}",
                                Value = a.Id.ToString()
                            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCompaniesAsync()
        {
            return await _movieDbContext
                            .Companies.Select(c => new SelectListItem
                            {
                                Text = c.Name,
                                Value = c.Id.ToString()
                            }).ToListAsync();
        }

        public async Task<List<CheckboxModel>> GetDirectorsAsync()
        {
            return await _movieDbContext
                  .Directors
                  .Select(d => new CheckboxModel
                  {
                    Id = d.Id,
                    Value = $"{d.Firstname} {d.Lastname}"
                  }).ToListAsync();
        }
    }
}
