using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projectoFinalV2.Models;

namespace projectoFinalV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db     = db;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Index()
        {
            var model = _db.Films.ToList();
            return View(model);
        }

        public IActionResult Movies()
        {
            var viewModel = new FilmPeople
            {
                Films  = _db.Films.ToList(),
                People = _db.People.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Final(string filmId)
        {
            var film = _db.Films.Find(filmId);
            if (film == null) 
                return NotFound();

            var people = _db.People
                .Where(p => p.films.Any(u => u.EndsWith($"/{filmId}")))
                .ToList();

            var viewModel = new FilmPeople
            {
                Films  = new List<Film> { film },
                People = people
            };
            return View(viewModel);
        }

        // --- Aquí estaba el error: faltaba el GET Rate ---
        [HttpGet]
        public IActionResult Rate(string filmId)
        {
            var film = _db.Films.Find(filmId);
            if (film == null)
                return NotFound();

            var ratings = _db.Ratings
                .Where(r => r.FilmId == filmId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            var vm = new FilmRatings
            {
                Film      = film,
                Ratings   = ratings,
                NewRating = new Rating { FilmId = filmId }
            };
            return View(vm);
        }

        // POST para guardar una nueva valoración
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rate(FilmRatings vm)
        {
            // 1) Loguea los errores del ModelState
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    _logger.LogInformation($"Key: {entry.Key}, Error: {error.ErrorMessage}");
                }
            }

            // 2) Comprueba validez y, si falla, recarga la vista
            if (!ModelState.IsValid)
            {
                vm.Film    = _db.Films.Find(vm.NewRating.FilmId);
                vm.Ratings = _db.Ratings
                    .Where(r => r.FilmId == vm.NewRating.FilmId)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();
                return View(vm);
            }

            // 3) Si todo es válido, guarda en base de datos
            vm.NewRating.CreatedAt = DateTime.UtcNow;
            _db.Ratings.Add(vm.NewRating);
            _db.SaveChanges();
            return RedirectToAction(nameof(Rate), new { filmId = vm.NewRating.FilmId });
        }
    }
}
