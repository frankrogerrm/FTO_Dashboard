using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class Holiday
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
