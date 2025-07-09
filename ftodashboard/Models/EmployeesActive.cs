using System;

#nullable disable

namespace ftodashboard.Models
{
    public partial class EmployeesActive
    {
        public int EmplNo { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Company { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameNo { get; set; }
        public string HomeCostCenter { get; set; }
        public string HomeCostCenterTrimmed { get; set; }
        public string HomeCostCenterDesc { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? RehireDate { get; set; }
        public string JobType { get; set; }
        public string JobDescription { get; set; }
        public string JobStep { get; set; }
        public string JobStepDesc { get; set; }
        public string JobTypeStepDescNo { get; set; }
        public string HourlySalary { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Aduser { get; set; }
        public string Ademail { get; set; }
        public string DivisionDistrictDesc { get; set; }
        public string ProfitServiceCenter { get; set; }
        public string AdminOrCraft { get; set; }
    }
}
