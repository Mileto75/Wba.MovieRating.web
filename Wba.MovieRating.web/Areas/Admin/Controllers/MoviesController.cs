using Microsoft.AspNetCore.Mvc;

namespace Wba.MovieRating.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
