namespace ScheduleTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Time_TourSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "Link", c => c.String());
            AddColumn("dbo.Tours", "Link", c => c.String());
            AddColumn("dbo.TourSchedules", "Link", c => c.String());
            AddColumn("dbo.TourSchedules", "TimeStart", c => c.Int(nullable: false));
            AddColumn("dbo.TourSchedules", "TimeIn", c => c.Int(nullable: false));
            AddColumn("dbo.TourSchedules", "TimeFree", c => c.Int(nullable: false));
            DropColumn("dbo.Destinations", "Url");
            DropColumn("dbo.Tours", "Url");
            DropColumn("dbo.TourSchedules", "Url");
            DropColumn("dbo.TourSchedules", "SecondStart");
            DropColumn("dbo.TourSchedules", "SecondIn");
            DropColumn("dbo.TourSchedules", "SecondFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TourSchedules", "SecondFree", c => c.Int(nullable: false));
            AddColumn("dbo.TourSchedules", "SecondIn", c => c.Int(nullable: false));
            AddColumn("dbo.TourSchedules", "SecondStart", c => c.Int(nullable: false));
            AddColumn("dbo.TourSchedules", "Url", c => c.String());
            AddColumn("dbo.Tours", "Url", c => c.String());
            AddColumn("dbo.Destinations", "Url", c => c.String());
            DropColumn("dbo.TourSchedules", "TimeFree");
            DropColumn("dbo.TourSchedules", "TimeIn");
            DropColumn("dbo.TourSchedules", "TimeStart");
            DropColumn("dbo.TourSchedules", "Link");
            DropColumn("dbo.Tours", "Link");
            DropColumn("dbo.Destinations", "Link");
        }
    }
}
