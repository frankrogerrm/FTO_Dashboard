using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class VTimeCardDateDimension
    {
        public DateTime? TheDate { get; set; }
        public int? TheDayOfWeek { get; set; }
        public DateTime? TheLastOfWeek { get; set; }
        public string Style101 { get; set; }
        public string DayNameDate { get; set; }
        public string TheDayName { get; set; }
    }
}
