using Microsoft.AspNetCore.Mvc;

namespace Wba.MovieRating.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
