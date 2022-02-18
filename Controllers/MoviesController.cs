using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies


        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer> {
                new Customer {Name = "Customer 1"},
                new Customer {Name ="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Cutomers = customers
            };

            return View(viewModel);
        }


        public ActionResult AllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek"},
                new Movie {Name ="Wall-E"}
            };
            return View(movies);
        }



    }
}