namespace PhilosophersLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PhilosopherID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                        Philosopher_PhilosopherID = c.Int(),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Philosopher", t => t.Philosopher_PhilosopherID)
                .ForeignKey("dbo.Philosopher", t => t.PhilosopherID)
                .Index(t => t.PhilosopherID)
                .Index(t => t.AreaID)
                .Index(t => t.Philosopher_PhilosopherID);
            
            CreateTable(
                "dbo.Philosopher",
                c => new
                    {
                        PhilosopherID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateOfDeath = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsAlive = c.Boolean(nullable: false),
                        Description = c.String(),
                        NationalityID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhilosopherID)
                .ForeignKey("dbo.Area", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Nationality", t => t.NationalityID, cascadeDelete: true)
                .Index(t => t.NationalityID)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.Nationality",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NationalityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "PhilosopherID", "dbo.Philosopher");
            DropForeignKey("dbo.Philosopher", "NationalityID", "dbo.Nationality");
            DropForeignKey("dbo.Book", "Philosopher_PhilosopherID", "dbo.Philosopher");
            DropForeignKey("dbo.Philosopher", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Book", "AreaID", "dbo.Area");
            DropIndex("dbo.Philosopher", new[] { "AreaID" });
            DropIndex("dbo.Philosopher", new[] { "NationalityID" });
            DropIndex("dbo.Book", new[] { "Philosopher_PhilosopherID" });
            DropIndex("dbo.Book", new[] { "AreaID" });
            DropIndex("dbo.Book", new[] { "PhilosopherID" });
            DropTable("dbo.Nationality");
            DropTable("dbo.Philosopher");
            DropTable("dbo.Book");
            DropTable("dbo.Area");
        }
    }
}
