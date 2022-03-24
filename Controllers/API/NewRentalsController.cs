using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        Model1 db = new Model1();
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDTO newRental)
        {

            var customer = db.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = db.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.AvailableStock == 0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.AvailableStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = System.DateTime.Now
                };

                db.Rentals.Add(rental);
            }

            db.SaveChanges();

            return Ok(db);
        }

    }
}
