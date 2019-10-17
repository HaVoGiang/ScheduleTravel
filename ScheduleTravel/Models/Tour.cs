using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleTravel.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Destination")]
        public int DestinationId { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public float locationX { get; set; }

        public float locationY { get; set; }

        public string Link { get; set; }

        public bool Publish { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TourSchedule> TourSchedules { get; set; }

        public virtual Destination Destination { get; set; }
    }
}