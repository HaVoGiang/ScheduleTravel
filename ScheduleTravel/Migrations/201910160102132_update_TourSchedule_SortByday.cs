namespace ScheduleTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_TourSchedule_SortByday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourSchedules", "SortByDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourSchedules", "SortByDay");
        }
    }
}
