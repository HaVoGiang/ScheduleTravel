namespace ScheduleTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_All_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        SortOrder = c.Int(nullable: false),
                        Publish = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinationId = c.Int(nullable: false),
                        Title = c.String(),
                        Price = c.Int(nullable: false),
                        locationX = c.Single(nullable: false),
                        locationY = c.Single(nullable: false),
                        Url = c.String(),
                        Publish = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.TourSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        SecondStart = c.Int(nullable: false),
                        SecondIn = c.Int(nullable: false),
                        SecondFree = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.TourId)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Adults = c.Int(nullable: false),
                        Kids = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourSchedules", "TourId", "dbo.Tours");
            DropForeignKey("dbo.TourSchedules", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Tours", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.TourSchedules", new[] { "ScheduleId" });
            DropIndex("dbo.TourSchedules", new[] { "TourId" });
            DropIndex("dbo.Tours", new[] { "DestinationId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.TourSchedules");
            DropTable("dbo.Tours");
            DropTable("dbo.Destinations");
        }
    }
}
