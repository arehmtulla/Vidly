namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedCustomerBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("update customers set Birthdate = '01/01/1997' where Id = 1");
        }

        public override void Down()
        {
        }
    }
}
