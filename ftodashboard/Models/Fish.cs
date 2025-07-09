using System.ComponentModel.DataAnnotations;

namespace ftodashboard.Models
{
    public class Fish
    {
        [Key]
        public int FishID { get; set; }
        [Display(Name = "Fish Name:")]
        public string Name { get; set; } = "";
    }
}
