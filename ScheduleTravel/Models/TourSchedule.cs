using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleTravel.Models
{
    public class TourSchedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }

        public int SortByDay { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public int TimeStart { get; set; } // Minutes

        public int TimeIn { get; set; } // Minutes

        public int TimeFree { get; set; } // Minutes

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}