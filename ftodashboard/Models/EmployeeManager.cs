#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace ftodashboard.Models
{
    public partial class EmployeeManager
    {
        [ForeignKey("Employee")]
        public int EmplId { get; set; }
        public string EmplName { get; set; }
        public int MgrId { get; set; }
    }
}
