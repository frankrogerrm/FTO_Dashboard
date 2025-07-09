using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class CalendarDimension
    {
        public int TheYear { get; set; }
        public string CalendarMonth { get; set; }
        public int TheDay { get; set; }
        public DateTime TheDate { get; set; }
        public DateTime TheStartOfWeek { get; set; }
        public DateTime TheEndOfWeek { get; set; }
        public int TheDayOfWeek { get; set; }
        public bool IsWeekend { get; set; }
        public string TheDayName { get; set; }
        public bool PrevNext { get; set; }
    }
}
