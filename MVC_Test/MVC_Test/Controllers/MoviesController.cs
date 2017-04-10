using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Models;
using MVC_Test.ViewModels;
using System.Data.Entity;

namespace MVC_Test.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie() {Name = "Taco's Attack", Description = "Super Tacos attack things"};
        //    return View(movie);
        //    //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        //}
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Taco's Attack", Description = "Super Tacos attack things" };
            //var customers = new List<Customer>()
            //{
            //    new Customer {Name = "Jeff"},
            //    new Customer {Name = "John"}
            //};
            var customers = new List<Customer>();
            customers.Add(new Customer("Jeff"));
            customers.Add(new Customer("Johh"));
            customers.Add(new Customer("Smam"));
            customers.Add(new Customer("Crista"));
            customers.Add(new Customer("Lorde"));
            customers.Add(new Customer("Lulz"));


            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            //return View(movie);
            return View(viewModel);
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }
        [Route("movies/released/{year:regex(\\d{4}$):length(4)}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }


        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        //}

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };


            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);
                existingMovie.Name = movie.Name;
                existingMovie.GenreId = movie.GenreId;
                existingMovie.StockAvailable = movie.StockAvailable;
                existingMovie.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }


        public ViewResult Index()
        {

            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "TacoTanic"},
                new Movie {Id = 2, Name = "MashedTomatos"}

            };
        }
    }
}