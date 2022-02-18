using System.Data.Entity;
using Vidly.Models;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
