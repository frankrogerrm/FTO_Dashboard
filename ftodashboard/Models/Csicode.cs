#nullable disable

namespace ftodashboard.Models
{
    public partial class Csicode
    {
        public long Uniqueid { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public int Csilevel { get; set; }
        public int Isheading { get; set; }
        public string Parentcode { get; set; }
        public int? Parentuniqueid { get; set; }
    }
}
