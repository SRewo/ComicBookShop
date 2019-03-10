namespace ComicBookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeriesUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComicBooks", "Series_Id", "dbo.Series");
            DropIndex("dbo.ComicBooks", new[] { "Series_Id" });
            AlterColumn("dbo.ComicBooks", "Series_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ComicBooks", "Series_Id");
            AddForeignKey("dbo.ComicBooks", "Series_Id", "dbo.Series", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComicBooks", "Series_Id", "dbo.Series");
            DropIndex("dbo.ComicBooks", new[] { "Series_Id" });
            AlterColumn("dbo.ComicBooks", "Series_Id", c => c.Int());
            CreateIndex("dbo.ComicBooks", "Series_Id");
            AddForeignKey("dbo.ComicBooks", "Series_Id", "dbo.Series", "Id");
        }
    }
}
