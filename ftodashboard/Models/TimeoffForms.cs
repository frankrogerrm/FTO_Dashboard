using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ftodashboard.Models
{
    [Table("Timeoff_Forms")]
    public class TimeoffForms
    {
        public int EmployeeNo { get; set; }
        public int ID { get; set; }        

    }
}
