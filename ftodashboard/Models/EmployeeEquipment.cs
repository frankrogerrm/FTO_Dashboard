using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class EmployeeEquipment
    {
        public int ItemNo { get; set; }
        public string UnitNo { get; set; }
        public string SerialNo { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public int AdrbookNo { get; set; }
        public string Location { get; set; }
        public DateTime EffDate { get; set; }
        public DateTime AcquiredDate { get; set; }
        public string ModelNo { get; set; }
        public string Status { get; set; }
    }
}
