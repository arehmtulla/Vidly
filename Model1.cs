using System.Data.Entity;

namespace Vidly
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=fresh")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
<<<<<<< HEAD
=======
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }
>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
