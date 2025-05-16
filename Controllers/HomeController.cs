using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            // Trae todas las películas desde la BD local
            var model = _db.Films.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            // Crea el ViewModel a partir de las tablas Films y People
            var viewModel = new FilmPeople
            {
                Films  = _db.Films.ToList(),
                People = _db.People.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Final(string filmId)
        {
            // Recupera la película por su clave primaria
            var film = _db.Films.Find(filmId);
            if (film == null)
                return NotFound();

            // Filtra las personas cuyo listado de URLs contenga el filmId al final
            var people = _db.People
                .Where(p => p.films.Any(url => url.EndsWith($"/{filmId}")))
                .ToList();

            var viewModel = new FilmPeople
            {
                Films  = new List<Film> { film },
                People = people
            };
            return View(viewModel);
        }

    }
}
