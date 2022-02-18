namespace Vidly.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Vidly.Models;

    public partial class SeedMovieDetails3 : DbMigration
    {
        private Model1 context = new Model1();


        public override void Up()
        {
            IList<Movie> movies = new List<Movie>()
             {
                new Movie {Id = 1, Name = "Shrek", DateAdded="10/2/2002", NumberInStock = 69, ReleaseDate= "02/02/2001"},
                new Movie {Id = 2, Name = "Wall E", DateAdded="10/2/2003", NumberInStock = 420, ReleaseDate= "02/02/2002"},
                new Movie {Id = 3, Name = "101 Dalmations", DateAdded="10/2/2004", NumberInStock = 2, ReleaseDate= "02/02/2003"},
                new Movie {Id = 4, Name = "Up", DateAdded="10/2/2005", NumberInStock = 7, ReleaseDate= "02/02/2004"},
                new Movie {Id = 5, Name = "Ice Age", DateAdded="10/2/2006", NumberInStock = 3, ReleaseDate= "02/02/2005"},
             };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }

        public override void Down()
        {
        }
    }
}
