using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleTravel.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Adults { get; set; }

        public int Kids { get; set; }

        public virtual ICollection<TourSchedule> TourSchedules { get; set; }
    }
}