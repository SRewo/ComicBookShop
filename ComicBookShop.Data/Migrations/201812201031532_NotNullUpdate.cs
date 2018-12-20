namespace ComicBookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComicBookArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.Series", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.OrderItems", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.ComicBookArtists", new[] { "Artist_Id" });
            DropIndex("dbo.ComicBookArtists", new[] { "ComicBook_Id" });
            DropIndex("dbo.Series", new[] { "Publisher_Id" });
            DropIndex("dbo.OrderItems", new[] { "ComicBook_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            AlterColumn("dbo.Artists", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Artists", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.ComicBookArtists", "Artist_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ComicBookArtists", "ComicBook_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ComicBooks", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "Publisher_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address_StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address_City", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address_PostalCode", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address_Country", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address_Region", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.OrderItems", "ComicBook_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Employee_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ComicBookArtists", "Artist_Id");
            CreateIndex("dbo.ComicBookArtists", "ComicBook_Id");
            CreateIndex("dbo.Series", "Publisher_Id");
            CreateIndex("dbo.OrderItems", "ComicBook_Id");
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.ComicBookArtists", "Artist_Id", "dbo.Artists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Series", "Publisher_Id", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "ComicBook_Id", "dbo.ComicBooks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.OrderItems", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.Series", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.ComicBookArtists", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.OrderItems", new[] { "ComicBook_Id" });
            DropIndex("dbo.Series", new[] { "Publisher_Id" });
            DropIndex("dbo.ComicBookArtists", new[] { "ComicBook_Id" });
            DropIndex("dbo.ComicBookArtists", new[] { "Artist_Id" });
            AlterColumn("dbo.Orders", "Employee_Id", c => c.Int());
            AlterColumn("dbo.OrderItems", "ComicBook_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Employees", "Login", c => c.String());
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Employees", "Address_Region", c => c.String());
            AlterColumn("dbo.Employees", "Address_Country", c => c.String());
            AlterColumn("dbo.Employees", "Address_PostalCode", c => c.String());
            AlterColumn("dbo.Employees", "Address_City", c => c.String());
            AlterColumn("dbo.Employees", "Address_StreetName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Series", "Publisher_Id", c => c.Int());
            AlterColumn("dbo.Series", "Name", c => c.String());
            AlterColumn("dbo.ComicBooks", "Title", c => c.String());
            AlterColumn("dbo.ComicBookArtists", "ComicBook_Id", c => c.Int());
            AlterColumn("dbo.ComicBookArtists", "Artist_Id", c => c.Int());
            AlterColumn("dbo.Artists", "LastName", c => c.String());
            AlterColumn("dbo.Artists", "FirstName", c => c.String());
            CreateIndex("dbo.Orders", "Employee_Id");
            CreateIndex("dbo.OrderItems", "ComicBook_Id");
            CreateIndex("dbo.Series", "Publisher_Id");
            CreateIndex("dbo.ComicBookArtists", "ComicBook_Id");
            CreateIndex("dbo.ComicBookArtists", "Artist_Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.OrderItems", "ComicBook_Id", "dbo.ComicBooks", "Id");
            AddForeignKey("dbo.Series", "Publisher_Id", "dbo.Publishers", "Id");
            AddForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks", "Id");
            AddForeignKey("dbo.ComicBookArtists", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
