using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesSerivce _service;
        public MoviesController(IMoviesSerivce service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        { 
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString));
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }

        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        
        public async Task<IActionResult> Create()
        {
            var movieDropdonwsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdonwsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdonwsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdonwsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdonwsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdonwsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdonwsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdonwsData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            if(movieDetail == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetail.Id,
                Name = movieDetail.Name,
                Description = movieDetail.Description,
                Price = movieDetail.Price,
                ImageURL = movieDetail.ImageURL,
                StartDate = movieDetail.StartDate,
                EndDate = movieDetail.EndDate,
                MovieCategory = movieDetail.MovieCategory,
                ActorIds = movieDetail.Actor_Movies.Select(n => n.ActorId).ToList(),
                ProducerId = movieDetail.ProducerId,
                CinemaId = movieDetail.CinemaId,
            };
            var movieDropdonwsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdonwsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdonwsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdonwsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdonwsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdonwsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdonwsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdonwsData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
