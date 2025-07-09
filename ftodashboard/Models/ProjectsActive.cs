using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class ProjectsActive
    {
        public string CostCenter { get; set; }
        public string CostCenterTrimmed { get; set; }
        public string Name { get; set; }
        public DateTime? PlannedStart { get; set; }
        public DateTime? ActualStart { get; set; }
        public DateTime? PlannedComplete { get; set; }
        public DateTime? ActualComplete { get; set; }
    }
}
