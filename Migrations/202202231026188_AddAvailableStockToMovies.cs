namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddAvailableStockToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));

            Sql("update Movies set AvailableStock = NumberInStock");
        }

        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
