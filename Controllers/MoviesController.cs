using System.Collections.Generic;
using System.Data.Entity;
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
            var movies = db.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }


        public ActionResult Details(int id)
        {
            var movie = db.Movies.SingleOrDefault(x => x.Id == id);
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = db.Genres.ToList();

            var viewModel = new FormMovieViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new FormMovieViewModel()
            {
                Movie = movie,
                Genres = db.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new FormMovieViewModel()
                {
                    Movie = movie,
                    Genres = db.Genres.ToList(),
                };
                return View("MovieForm", viewModel);
            };

            if (movie.Id == 0)
            {
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(x => x.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
            }

            db.SaveChanges();

            return RedirectToAction("AllMovies", "Movies");
        }

    }
}