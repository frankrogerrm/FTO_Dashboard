using System;
using System.ComponentModel.DataAnnotations;


namespace ftodashboard.Models
{
    public class EmployeeTemplate
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
