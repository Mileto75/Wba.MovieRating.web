using Microsoft.AspNetCore.Mvc.Rendering;
using Wba.MovieRating.Web.Areas.Admin.Models;

namespace Wba.MovieRating.Web.Services.Interfaces
{
    public interface IFormBuilderService
    {
        Task<IEnumerable<SelectListItem>> GetCompaniesAsync();
        Task<IEnumerable<SelectListItem>> GetActorsAsync();
        Task<List<CheckboxModel>> GetDirectorsAsync();
    }
}
