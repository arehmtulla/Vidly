namespace Vidly.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Vidly.Models;

    public partial class SeedingData : DbMigration
    {
        Model1 context = new Model1();

        public override void Up()
        {
            IList<Movie> movies = new List<Movie>()
            {
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Wall-E", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="The Shining", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
                new Movie() {Name ="Shrek", NumberInStock=69, DateAdded="01/02/2003", Genre="Horror", ReleaseDate ="01/02/2002"},
            };

            context.Movies.AddRange(movies);

            IList<Customer> customers = new List<Customer>() {
                new Customer() {Name = "Abdul Rahman", Birthdate="17/01/1996", IsSubscribedToNewsLetter=false, MembershipTypeId=1 },
                new Customer() {Name = "Ben Geoffrey", Birthdate="17/01/1986", IsSubscribedToNewsLetter=false, MembershipTypeId=3 },
                new Customer() {Name = "James Oslem", Birthdate="17/01/1999", IsSubscribedToNewsLetter=true, MembershipTypeId=2 },
                 };

            context.Customers.AddRange(customers);

            IList<MembershipType> membershipTypes = new List<MembershipType>() {
                new MembershipType() {Name = "Pay As You Go", Id = 1, DiscountRate = 0, DurationInMonths=0, SignUpFee= 0},
                new MembershipType() {Name = "Pay As You Go", Id = 2, DiscountRate = 10, DurationInMonths=1, SignUpFee= 30},
                new MembershipType() {Name = "Pay As You Go", Id = 3, DiscountRate = 15, DurationInMonths=3, SignUpFee= 80},
                new MembershipType() {Name = "Pay As You Go", Id = 4, DiscountRate = 20, DurationInMonths=12, SignUpFee= 300},
            };

            context.MembershipTypes.AddRange(membershipTypes);

            context.SaveChanges();

        }

        public override void Down()
        {
        }
    }
}
