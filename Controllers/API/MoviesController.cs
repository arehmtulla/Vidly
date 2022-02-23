using AutoMapper;
using System;
using System.Data.Entity;

using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private Model1 db = new Model1();

        //GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var movieDtos = db.Movies
                .Include(x => x.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(movieDtos);
        }

        //GET /api/movies/:id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //POST /api/movies/:id
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            db.Movies.Add(movie);
            db.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movieDTO);
        }

        //PUT /api/movies/:id
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = db.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDTO, Movie>(movieDTO, movieInDb);


            db.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = db.Movies.SingleOrDefault(c => c.Id == id);

            db.Movies.Remove(movieInDb);
            db.SaveChanges();
        }
    }
}
