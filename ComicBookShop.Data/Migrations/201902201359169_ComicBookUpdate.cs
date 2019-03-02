namespace ComicBookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComicBookUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks");
            DropIndex("dbo.ComicBookArtists", new[] { "ComicBook_Id" });
            AlterColumn("dbo.ComicBookArtists", "ComicBook_Id", c => c.Int());
            CreateIndex("dbo.ComicBookArtists", "ComicBook_Id");
            AddForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks");
            DropIndex("dbo.ComicBookArtists", new[] { "ComicBook_Id" });
            AlterColumn("dbo.ComicBookArtists", "ComicBook_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ComicBookArtists", "ComicBook_Id");
            AddForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks", "Id", cascadeDelete: true);
        }
    }
}
