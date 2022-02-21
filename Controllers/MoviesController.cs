using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        private Model1 db = new Model1();


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
            var movies = db.Movies.ToList();

            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = db.Movies.SingleOrDefault(x => x.Id == id);
            return View(movie);
        }


    }
}