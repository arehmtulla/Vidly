using System.Data.Entity;

namespace Vidly
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Fresh")
        {
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
