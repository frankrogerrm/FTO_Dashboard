using System;

namespace ftodashboard.Models
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public int MprId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsComplete { get; set; } = false;
        public DateTime? CompleteDate { get; set; }
        public string Notes { get; set; } = "";
        public bool IsApprover { get; set; } = false;

        public Employee Employee { get; set; } = new Employee();
    }
}