namespace Vidly.Migrations
{
    using System.Collections;
    using System.Data.Entity.Migrations;
    using Vidly.Models;

    public partial class SeedingData : DbMigration
    {
        Model1 context = new Model1();

        public override void Up()
        {
            IList movies = new List<Movie>()
            {
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Wall-E", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="The Shining", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
            };

        }

        public override void Down()
        {
        }
    }
}
