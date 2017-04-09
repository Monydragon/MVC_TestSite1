using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Models;
using MVC_Test.ViewModels;

namespace MVC_Test.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
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

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
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