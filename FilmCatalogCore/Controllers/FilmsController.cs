using System.Linq;
using System.Threading.Tasks;
using FilmCatalogCore.Data;
using FilmCatalogCore.Data.Entities;
using FilmCatalogCore.Models;
using FilmCatalogCore.Services.Films;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FilmCatalogCore.Controllers
{
    [Authorize]
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFilmService _filmService;
        private string UserName => User.Identity.IsAuthenticated ?  User.Identity.Name : null;

        public FilmsController(ApplicationDbContext context, IFilmService filmService)
        {
            _context = context;
            _filmService = filmService;
        }

        // GET: Films
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var films = await _filmService.GetFilmList();
            
            //var applicationDbContext = _context.Films.Include(f => f.Poster).Include(f => f.User);
            return View(films);
        }

        // GET: Films/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null && UserName != null)
            {
                var film = await _filmService.GetById((int) id);
                if (film == null)
                {
                    return NotFound();
                }

                return View(film);
            }

            return NotFound();
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmCreateModel film)
        {
            if (ModelState.IsValid && UserName != null)
            {
                await _filmService.Create(film);
                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _filmService.GetEditFilm((int) id);
            if (film == null)
            {
                return NotFound();
            }
            
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FilmEditModel film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _filmService.EditFilm(film);

                return RedirectToAction(nameof(Index));
            }
            
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _filmService.GetById((int) id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _filmService.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}