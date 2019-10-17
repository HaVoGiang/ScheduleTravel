using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleTravel.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public int SortOrder { get; set; }

        public bool Publish { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}