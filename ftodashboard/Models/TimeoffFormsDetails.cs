using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ftodashboard.Models
{
    [Table("Timeoff_Forms_Detail")]
    public class TimeoffFormsDetails
    {
        public DateTime DateWorked { get; set; }
        public double HoursWorked { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ID { get; set; }
    }
}
