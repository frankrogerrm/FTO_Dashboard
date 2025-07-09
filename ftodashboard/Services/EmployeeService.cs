using ftodashboard.Data;
using ftodashboard.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Telerik.DataSource.Extensions;


namespace ftodashboard.Services
{
    public class EmployeeService
    {
        //Property
        private readonly CommonDataSourceContext _dbContext;

        private readonly TimeSheetAppContext _tsContext;

        //Constructor
        public EmployeeService(CommonDataSourceContext dbContext, TimeSheetAppContext dbContext2)
        {
            _dbContext = dbContext;
            _tsContext = dbContext2;
        }

        //reference objects for ID lookup
        public List<Employee> GetEmployeeObjects()
        {
            return _dbContext.Employees
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .ToList();
        }

        public List<string> GetMonthNumToString(int month)
        {
            List<string> monthString = _dbContext.DateDimensions
                                    .Where(a => a.TheMonth == month)
                                    .Select(a => a.TheMonthName)
                                    .Distinct()
                                    .ToList();
            return monthString;
        }

        public List<string> GetMonthNumFromString(string monthNameYear)
        {
            var monthName = monthNameYear.Remove(monthNameYear.Length - 5);
            var year = monthNameYear.Substring(monthNameYear.Length - 4, 4);

            List<string> monthYear = _dbContext.DateDimensions
                                    .Where(a => a.TheMonthName == monthName)
                                    .Where(a => a.TheYear == Convert.ToInt32(year))
                                    .Select(a => a.TheMonth + " " + a.TheYear)
                                    .Distinct()
                                    .ToList();
            return monthYear;
        }

        //previous one, current and next 11 month names
        public List<string> GetMonthNames()
        {
            List<DateDimension> list3 = _dbContext.DateDimensions
                                .Where(n => n.TheDay == 1)
                                .Where(n => n.TheDate <= DateTime.Now.Date)
                                .ToList();

            DateDimension prevmonth = new DateDimension();

            var n = list3.Count() - 2;

            prevmonth = list3[n];
            List<DateDimension> prevmonthList = new List<DateDimension>();
            prevmonthList.Add(prevmonth);

            List<DateDimension> list = _dbContext.DateDimensions
                                .Where(n => n.TheDate == DateTime.Now.Date)
                                .Take(1)
                                .ToList();

            List<DateDimension> list2 = _dbContext.DateDimensions
                                .Where(n => n.TheDay == 1)
                                .Where(n => n.TheDate >= DateTime.Now.Date)
                                .Take(11)
                                .ToList();

            var listfinal = prevmonthList.Concat(list).Concat(list2);

            List<string> dateStrings = listfinal
                     .Select(a => a.TheMonthName + " " + a.TheYear)
                     .ToList();

            return dateStrings;
        }

        //current and next 11 month nums + year
        public List<string> GetMonthNums()
        {
            List<DateDimension> list = _dbContext.DateDimensions
                                .Where(n => n.TheDate == DateTime.Now.Date)
                                .Take(1)
                                .ToList();

            List<DateDimension> list2 = _dbContext.DateDimensions
                                .Where(n => n.TheDay == 1)
                                .Where(n => n.TheDate >= DateTime.Now.Date)
                                .Take(11)
                                .ToList();

            var listfinal = list.Concat(list2);

            List<string> dateStrings = listfinal
                     .Select(a => a.TheMonth + " " + a.TheYear)
                     .ToList();

            return dateStrings;
        }

        //Initial population of employee filter
        public List<string> GetManagers()
        {
            List<Employee> emplList = _dbContext.Employees
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Distinct()
                .OrderBy(name => name).ToList();

            List<EmployeeManager> emplList2 = _dbContext.EmployeeManagers.ToList();

            List<Employee> mgrList = emplList
                .Where(a => emplList2.Exists(b => b.MgrId == Convert.ToDouble(a.EmplNo)))
                .ToList();

            List<string> managerStrings = mgrList
                .Select(a => a.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            return managerStrings;
        }

        //Initial population of employee filter
        public List<string> GetEmployees()
        {
            return _dbContext.Employees
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Select(a => a.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();
        }

        //Initial population of employee filter
        public List<string> GetProjectNumbers()
        {
            return _dbContext.Employees
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Where(a => a.LastJobWorked.Length >= 5)
                .Join(_dbContext.ProjectsActives, a => a.LastJobWorked, b => b.CostCenterTrimmed, (a, b) => a.LastJobWorked + " - " + b.Name)
                //.Select(a => a.LastJobWorked)
                .Distinct()
                .OrderBy(project => project)
                .ToList();
        }

        //this one isnt used but the codes nice so keeping it for reference
        public List<ProjectList> GetEmployeeProjects()
        {
            List<ProjectList> ProjectListResults = new List<ProjectList>();

            //***Employee Object
            List<Employee> emp = _dbContext.Employees
                                        .Where(a => a.EmployeeStatus == "ACTIVE")
                                        .Where(a => a.AdminOrCraft == "ADMIN")
                                        .Where(a => a.LastJobWorked.Length >= 5)
                                        .Distinct()
                                        .OrderBy(project => project)
                                        .ToList();

            //***ProjectsActive Object
            List<ProjectsActive> proj = _dbContext.ProjectsActives
                                            .Distinct()
                                            .ToList();

            var projList = (from emp1 in emp
                            join proj1 in proj
                            on emp1.LastJobWorked equals proj1.CostCenterTrimmed
                            select new ProjectList
                            {
                                LastJobWorked = emp1.LastJobWorked,
                                JobName = proj1.Name
                            }).ToList();

            ProjectListResults = projList;

            return ProjectListResults;
        }

        //Initial population of home cost center filter
        public List<string> GetHomeCostCenters()
        {
            return _dbContext.Employees
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Where(a => a.HomeCostCenter.Length <= 4)
                .Select(a => a.HomeCostCenter + " - " + a.HomeCostCenterDesc)
                .Distinct()
                .OrderBy(home => home)
                .ToList();
        }

        //Initial population of division filter
        public List<string> GetDivisions()
        {
            return _dbContext.Employees
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Select(a => a.DivisionDesc)
                .Distinct()
                .OrderBy(div => div)
                .ToList();
        }

        //Initial population of groups (based on divisions)
        public List<string> GetGroups(string division = null)
        {
            var allGroupQuery = _dbContext.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(division))
            {
                allGroupQuery = allGroupQuery.Where(a => a.DivisionDesc == division);
            }

            return allGroupQuery
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Select(a => a.GroupDesc)
                .Distinct()
                .OrderBy(group => group)
                .ToList();
        }

        //Initial population of regions (based on divisions)
        public List<string> GetRegions(string group = null)
        {
            var allRegionQuery = _dbContext.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(group))
            {
                allRegionQuery = allRegionQuery.Where(a => a.GroupDesc == group);
            }

            return allRegionQuery
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Select(a => a.RegionDesc)
                .Distinct()
                .OrderBy(region => region)
                .ToList();
        }

        //Initial population of areas (based on regions)
        public List<string> GetTypes(string region = null)
        {
            var allTypeQuery = _dbContext.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(region))
            {
                allTypeQuery = allTypeQuery.Where(a => a.Region == region);
            }

            return allTypeQuery
                .Where(a => a.EmployeeStatus == "ACTIVE")
                .Where(a => a.AdminOrCraft == "ADMIN")
                .Select(a => a.TypeDesc)
                .Distinct()
                .OrderBy(type => type)
                .ToList();
        }

        //methods for grabbing filtered employee object lists and displaying them on the fto table

        public List<Employee> GetFilteredEmployees(double filter)
        {
            //filter object list by employee number
            return _dbContext.Employees.Where(a => a.EmplNo == filter).ToList();
        }

        public List<Employee> GetFilteredManagers(double filter)
        {
            //look up employees under a manager
            //use that list to filter employee object list

            return _dbContext.Employees.FromSqlRaw("[csp_FTODashboard_ManagerRecursion] {0}", Convert.ToInt32(filter)).ToList();

        }

        public List<Employee> GetFilteredProjects(string filter)
        {
            return _dbContext.Employees.Where(a => a.LastJobWorked == filter).ToList();
        }

        public List<Employee> GetFilteredProjects(List<string> ProjectList)
        {
            //find employees of project code from method parameter and put in temp list
            //add to result list 
            //clear temp list & repeat

            List<Employee> EmployeeResults = new List<Employee>();
            List<Employee> EmployeeListPerProject = new List<Employee>();

            foreach (string ProjectFull in ProjectList)
            {
                string ProjectCode = ProjectFull.Substring(0, 6);
                EmployeeListPerProject = _dbContext.Employees.Where(a => a.LastJobWorked == ProjectCode).ToList();
                EmployeeResults.AddRange(EmployeeListPerProject);
                EmployeeListPerProject.Clear();
            }

            return EmployeeResults;
        }

        //this one isnt used but the codes nice so keeping it for reference
        public List<Employee> GetFilteredProjects(List<ProjectList> ProjectList)
        {
            //find employees of project code
            //add to result list 
            //clear & repeat

            List<Employee> EmployeeResults = new List<Employee>();
            List<Employee> EmployeeListPerProject = new List<Employee>();

            foreach (ProjectList Project in ProjectList)
            {
                EmployeeListPerProject = _dbContext.Employees.Where(a => a.LastJobWorked == Project.LastJobWorked).ToList();
                EmployeeResults.AddRange(EmployeeListPerProject);
                EmployeeListPerProject.Clear();
            }

            return EmployeeResults;
        }

        public List<Employee> GetFilteredCostCenter(string filter)
        {
            return _dbContext.Employees.Where(a => a.HomeCostCenter == filter).ToList();
        }

        public List<Employee> GetFilteredDivision(string filter)
        {
            return _dbContext.Employees.Where(a => a.Division == filter).ToList();
        }

        public List<Employee> GetFilteredGroup(string filter)
        {
            return _dbContext.Employees.Where(a => a.Group == filter).ToList();
        }

        public List<Employee> GetFilteredRegion(string filter)
        {
            return _dbContext.Employees.Where(a => a.Region == filter).ToList();
        }

        public List<Employee> GetFilteredType(string filter)
        {
            return _dbContext.Employees.Where(a => a.Type == filter).ToList();
        }

        public List<EmployeeFTO> GetEmployeeFTO(string monthYear)
        {
            //record of the month with weekends/holidays
            List<VFTODashboardFTOMonth> monthList = _dbContext.V_FTODashboard_FTOMonths
                                            .Where(a => a.MMYYYY == monthYear)
                                            .ToList();

            //list of employees with FTO in the given month
            List<VFTODashboardFTOByMonth> ftoByMonthList = _tsContext.V_FTODashboard_FTOByMonth
                                            .Where(a => a.MMYYYY == monthYear)
                                            .ToList();

            List<EmployeeFTO> comboList = new List<EmployeeFTO>();

            if (monthList.Count > 0 && ftoByMonthList.Count > 0)
            {
                var result = (from l1 in monthList
                              join l2 in ftoByMonthList
                              on l1.MMYYYY equals l2.MMYYYY
                              select new EmployeeFTO
                              {
                                  EmployeeName = l2.EmployeeName,
                                  EmployeeNo = l2.EmployeeNo,
                                  MMYYYY = l1.MMYYYY,
                                  d1 = (l1.d1 == 0) ? l2.d1 : l1.d1,
                                  d2 = (l1.d2 == 0) ? l2.d2 : l1.d2,
                                  d3 = (l1.d3 == 0) ? l2.d3 : l1.d3,
                                  d4 = (l1.d4 == 0) ? l2.d4 : l1.d4,
                                  d5 = (l1.d5 == 0) ? l2.d5 : l1.d5,
                                  d6 = (l1.d6 == 0) ? l2.d6 : l1.d6,
                                  d7 = (l1.d7 == 0) ? l2.d7 : l1.d7,
                                  d8 = (l1.d8 == 0) ? l2.d8 : l1.d8,
                                  d9 = (l1.d9 == 0) ? l2.d9 : l1.d9,
                                  d10 = (l1.d10 == 0) ? l2.d10 : l1.d10,
                                  d11 = (l1.d11 == 0) ? l2.d11 : l1.d11,
                                  d12 = (l1.d12 == 0) ? l2.d12 : l1.d12,
                                  d13 = (l1.d13 == 0) ? l2.d13 : l1.d13,
                                  d14 = (l1.d14 == 0) ? l2.d14 : l1.d14,
                                  d15 = (l1.d15 == 0) ? l2.d15 : l1.d15,
                                  d16 = (l1.d16 == 0) ? l2.d16 : l1.d16,
                                  d17 = (l1.d17 == 0) ? l2.d17 : l1.d17,
                                  d18 = (l1.d18 == 0) ? l2.d18 : l1.d18,
                                  d19 = (l1.d19 == 0) ? l2.d19 : l1.d19,
                                  d20 = (l1.d20 == 0) ? l2.d20 : l1.d20,
                                  d21 = (l1.d21 == 0) ? l2.d21 : l1.d21,
                                  d22 = (l1.d22 == 0) ? l2.d22 : l1.d22,
                                  d23 = (l1.d23 == 0) ? l2.d23 : l1.d23,
                                  d24 = (l1.d24 == 0) ? l2.d24 : l1.d24,
                                  d25 = (l1.d25 == 0) ? l2.d25 : l1.d25,
                                  d26 = (l1.d26 == 0) ? l2.d26 : l1.d26,
                                  d27 = (l1.d27 == 0) ? l2.d27 : l1.d27,
                                  d28 = (l1.d28 == 0) ? l2.d28 : l1.d28,
                                  d29 = (l1.d29 == 0) ? l2.d29 : l1.d29,
                                  d30 = (l1.d30 == 0) ? l2.d30 : l1.d30,
                                  d31 = (l1.d31 == 0) ? l2.d31 : l1.d31,
                              }).ToList();
                comboList = result;
            }
            return comboList;
        }

        public List<EmployeeFTO> GetEmployeeFTOforGrid(List<EmployeeFTO> empFTOList, List<Employee> empFilterList)
        {
            var result = empFTOList.Where(a => empFilterList.Exists(b => b.EmplNo == a.EmployeeNo)).ToList();

            return result;
        }
    }
}

