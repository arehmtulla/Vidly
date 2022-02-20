using System.Data.Entity;
using Vidly.Models;

namespace Vidly.DAL
{
    public class VidlyContext : DbContext
    {

        public VidlyContext() : base("SchoolContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }


    }
}