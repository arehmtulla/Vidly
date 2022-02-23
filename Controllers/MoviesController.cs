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




        public ActionResult AllMovies()
        {

            return View();
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

            var viewModel = new FormMovieViewModel(movie)
            {
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
                var viewModel = new FormMovieViewModel(movie)
                {

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