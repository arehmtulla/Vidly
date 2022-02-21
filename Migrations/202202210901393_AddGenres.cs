namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ReleaseDate = c.String(),
                    DateAdded = c.String(),
                    NumberInStock = c.Int(nullable: false),
                })

                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            Sql("insert into genres (Id, Name) values (1, 'Horror')");
            Sql("insert into genres (Id, Name) values (2, 'Comedy')");
            Sql("insert into genres (Id, Name) values (3, 'Romance')");
            Sql("insert into genres (Id, Name) values (4, 'Actiom')");

            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));

            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
