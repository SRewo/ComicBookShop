namespace ComicBookShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComicBookArtists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Artist_Id = c.Int(),
                        ComicBook_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .ForeignKey("dbo.ComicBooks", t => t.ComicBook_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.ComicBook_Id);
            
            CreateTable(
                "dbo.ComicBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        OnSaleDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.Series_Id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Publisher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Job = c.String(),
                        Address_StreetName = c.String(),
                        Address_City = c.String(),
                        Address_PostalCode = c.String(),
                        Address_Country = c.String(),
                        Address_Region = c.String(),
                        PhoneNumber = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        ComicBook_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComicBooks", t => t.ComicBook_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.ComicBook_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.OrderItems", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.ComicBookArtists", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.ComicBooks", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.Series", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.ComicBookArtists", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "ComicBook_Id" });
            DropIndex("dbo.Series", new[] { "Publisher_Id" });
            DropIndex("dbo.ComicBooks", new[] { "Series_Id" });
            DropIndex("dbo.ComicBookArtists", new[] { "ComicBook_Id" });
            DropIndex("dbo.ComicBookArtists", new[] { "Artist_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Employees");
            DropTable("dbo.Publishers");
            DropTable("dbo.Series");
            DropTable("dbo.ComicBooks");
            DropTable("dbo.ComicBookArtists");
            DropTable("dbo.Artists");
        }
    }
}
