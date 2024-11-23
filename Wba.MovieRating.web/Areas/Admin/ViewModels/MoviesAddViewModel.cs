using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Wba.MovieRating.Web.Areas.Admin.Models;

namespace Wba.MovieRating.Web.Areas.Admin.ViewModels
{
    public class MoviesAddViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }
        [Display(Name = "Actors")]
        public IEnumerable<int> ActorIds { get; set; }
        public List<CheckboxModel> Directors { get; set; }
        public IFormFile Image { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
        [Display(Name = "Companies")]
        public int CompanyId { get; set; }

    }
}
