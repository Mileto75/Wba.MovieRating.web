using Microsoft.AspNetCore.Mvc;

namespace Wba.MovieRating.Web.Areas.Admin.ViewModels
{
    public class MoviesEditViewModel : MoviesAddViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
    }
}
