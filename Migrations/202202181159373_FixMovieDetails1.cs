namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixMovieDetails1 : DbMigration
    {
        public override void Up()
        {
            Sql("drop table movies");
        }

        public override void Down()
        {
        }
    }
}
