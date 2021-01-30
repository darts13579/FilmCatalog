using System.Threading.Tasks;
using FilmCatalogCore.Services.Films;
using Microsoft.AspNetCore.Mvc;

namespace FilmCatalogCore.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        
        public async Task<ActionResult> Index()
        {
            var films = await _filmService.GetFilmList();
            
            return View(films);
        }
    }
}