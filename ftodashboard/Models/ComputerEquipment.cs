using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class ComputerEquipment
    {
        public string UnitNo { get; set; }
        public string SerialNo { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public decimal AdrbookNo { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? LocationStart { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public string ModelNo { get; set; }
        public string Status { get; set; }
        public string ItemNo { get; set; }
    }
}
