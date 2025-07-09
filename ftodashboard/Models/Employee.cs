using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ftodashboard.Models
{
    [Table("Employees")]
    public partial class Employee
    {
        public double EmplNo { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string HomeCostCenter { get; set; }
        public string HomeCostCenterDesc { get; set; }
        public string LastJobWorked { get; set; }
        public string Division { get; set; }
        public string DivisionDesc { get; set; }
        public string Region { get; set; }
        public string RegionDesc { get; set; }
        public string Group { get; set; }
        public string GroupDesc { get; set; }
        public string Type { get; set; }
        public string TypeDesc { get; set; }
        public string EmployeeStatus { get; set; }
        public double Manager { get; set; }
        public string AdminOrCraft { get; set; }

    }
}
