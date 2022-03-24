<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using System.Linq;
>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies




        public ActionResult AllMovies()
        {
<<<<<<< HEAD
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek"},
                new Movie {Name ="Wall-E"}
            };
            return View(movies);
        }


=======

            return View();
        }

>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525

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