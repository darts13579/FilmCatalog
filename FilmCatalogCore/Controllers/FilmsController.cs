using Microsoft.AspNetCore.Mvc;

namespace FilmCatalogCore.Controllers
{
    public class FilmsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}