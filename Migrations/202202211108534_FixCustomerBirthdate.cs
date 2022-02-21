namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixCustomerBirthdate : DbMigration
    {
        public override void Up()
        {

            Sql("update Customers set Birthdate = '1996-01-17' where Id =1");
            Sql("update Customers set Birthdate = '2005-01-17' where Id =2");
            Sql("update Customers set Birthdate = '1997-01-17' where Id =3");
            Sql("update Customers set Birthdate = '2000-01-17' where Id =4");
            Sql("update Customers set Birthdate = '1993-01-17' where Id =5");
        }


        public override void Down()
        {
        }
    }
}
