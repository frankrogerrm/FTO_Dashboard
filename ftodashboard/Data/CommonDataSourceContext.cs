using Microsoft.EntityFrameworkCore;
using ftodashboard.Models;

#nullable disable

namespace ftodashboard.Data
{
    public partial class CommonDataSourceContext : DbContext
    {

        public CommonDataSourceContext(DbContextOptions<CommonDataSourceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalendarDimension> CalendarDimensions { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ComputerEquipment> ComputerEquipments { get; set; }
        public virtual DbSet<ComputerRelocationDistribution> ComputerRelocationDistributions { get; set; }
        public virtual DbSet<CostCodesLevel7> CostCodesLevel7s { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Csicode> Csicodes { get; set; }
        public virtual DbSet<DateDimension> DateDimensions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeEquipment> EmployeeEquipments { get; set; }
        public virtual DbSet<EmployeeManager> EmployeeManagers { get; set; }
        public virtual DbSet<EmployeePhone> EmployeePhones { get; set; }
        public virtual DbSet<EmployeesActive> EmployeesActives { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Paytype> Paytypes { get; set; }
        public virtual DbSet<ProjectsActive> ProjectsActives { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Subledger> Subledgers { get; set; }
        public virtual DbSet<Subledgetype> Subledgetypes { get; set; }
        public virtual DbSet<VAdmPermissionsByDatabaseRole> VAdmPermissionsByDatabaseRoles { get; set; }
        public virtual DbSet<VAdmPermissionsByObject> VAdmPermissionsByObjects { get; set; }
        public virtual DbSet<VCostCodesDropdown> VCostCodesDropdowns { get; set; }
        public virtual DbSet<VCostCodesLevel7Tibc> VCostCodesLevel7Tibcs { get; set; }
        public virtual DbSet<VCsicodedropdown> VCsicodedropdowns { get; set; }
        public virtual DbSet<VDistinctCostCentersTrimmed> VDistinctCostCentersTrimmeds { get; set; }
        public virtual DbSet<VDistinctCostCentersTrimmedType> VDistinctCostCentersTrimmedTypes { get; set; }
        public virtual DbSet<VDistinctCostCentersTrimmedTypeCode> VDistinctCostCentersTrimmedTypeCodes { get; set; }
        public virtual DbSet<VDistinctCostCode> VDistinctCostCodes { get; set; }
        public virtual DbSet<VDistinctCostTypeCode> VDistinctCostTypeCodes { get; set; }
        public virtual DbSet<VEmpIter> VEmpIters { get; set; }
        public virtual DbSet<VEmpIterDistinct> VEmpIterDistincts { get; set; }
        public virtual DbSet<VFullAccountNumber> VFullAccountNumbers { get; set; }
        public virtual DbSet<VManagerId> VManagerIds { get; set; }
        public virtual DbSet<VPayTypeDropdown> VPayTypeDropdowns { get; set; }
        public virtual DbSet<VSubledgerDropDown> VSubledgerDropDowns { get; set; }
        public virtual DbSet<VSubledgertypeDropdown> VSubledgertypeDropdowns { get; set; }
        public virtual DbSet<VTimeCardDateDimension> VTimeCardDateDimensions { get; set; }
        public virtual DbSet<VWeekendingDate> VWeekendingDates { get; set; }
        public virtual DbSet<VWeekendingDatesPayroll> VWeekendingDatesPayrolls { get; set; }
        public virtual DbSet<VFTODashboardFTOMonth> V_FTODashboard_FTOMonths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<VFTODashboardFTOMonth>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<CalendarDimension>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CalendarDimension");

                entity.Property(e => e.CalendarMonth)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.TheDate).HasColumnType("date");

                entity.Property(e => e.TheDayName)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.TheEndOfWeek).HasColumnType("date");

                entity.Property(e => e.TheStartOfWeek).HasColumnType("date");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyNo);

                entity.HasIndex(e => e.CompanyName, "idx_CompanyName");

                entity.Property(e => e.CompanyNo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComputerEquipment>(entity =>
            {
                entity.HasKey(e => e.UnitNo);

                entity.ToTable("Computer_Equipment");

                entity.HasIndex(e => e.Desc1, "idx_Desc1");

                entity.Property(e => e.UnitNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AcquiredDate).HasColumnType("date");

                entity.Property(e => e.AdrbookNo)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("ADRBookNo");

                entity.Property(e => e.Desc1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Desc2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LocationStart).HasColumnType("date");

                entity.Property(e => e.ModelNo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComputerRelocationDistribution>(entity =>
            {
                entity.HasKey(e => e.FullAccountNumber);

                entity.ToTable("ComputerRelocation_Distribution");

                entity.Property(e => e.FullAccountNumber)
                    .HasMaxLength(28)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenter)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterTrimmed)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CostCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CostCodeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PostingEditCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CostCodesLevel7>(entity =>
            {
                entity.HasKey(e => new { e.CostCenter, e.CostCode, e.Description })
                    .HasName("PK_CostCenterCostCodeDEsc");

                entity.ToTable("CostCodesLevel7");

                entity.Property(e => e.CostCode).HasMaxLength(8);

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.CostCenterDescription).HasMaxLength(30);

                entity.Property(e => e.DivisionCode).HasMaxLength(3);

                entity.Property(e => e.DivisionDesc).HasMaxLength(30);

                entity.Property(e => e.GroupCode).HasMaxLength(3);

                entity.Property(e => e.GroupDesc).HasMaxLength(30);

                entity.Property(e => e.RegionCode).HasMaxLength(3);

                entity.Property(e => e.RegionDesc).HasMaxLength(30);

                entity.Property(e => e.TypeCode).HasMaxLength(3);

                entity.Property(e => e.TypeDesc).HasMaxLength(30);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryKey);

                entity.Property(e => e.CountryId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Csicode>(entity =>
            {
                entity.HasKey(e => e.Uniqueid);

                entity.ToTable("CSICODE");

                entity.Property(e => e.Uniqueid)
                    .ValueGeneratedNever()
                    .HasColumnName("UNIQUEID");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.Csilevel).HasColumnName("CSILEVEL");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Isheading).HasColumnName("ISHEADING");

                entity.Property(e => e.Parentcode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PARENTCODE");

                entity.Property(e => e.Parentuniqueid).HasColumnName("PARENTUNIQUEID");
            });

            modelBuilder.Entity<DateDimension>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DateDimension");

                entity.HasIndex(e => e.TheDate, "PK_DateDimension")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Has53Isoweeks).HasColumnName("Has53ISOWeeks");

                entity.Property(e => e.Mmyyyy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MMYYYY")
                    .IsFixedLength(true);

                entity.Property(e => e.Style101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style112)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheDate).HasColumnType("date");

                entity.Property(e => e.TheDayName).HasMaxLength(30);

                entity.Property(e => e.TheDaySuffix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheFirstOfMonth).HasColumnType("date");

                entity.Property(e => e.TheFirstOfNextMonth).HasColumnType("date");

                entity.Property(e => e.TheFirstOfQuarter).HasColumnType("date");

                entity.Property(e => e.TheFirstOfWeek).HasColumnType("date");

                entity.Property(e => e.TheFirstOfYear).HasColumnType("date");

                entity.Property(e => e.TheIsoweek).HasColumnName("TheISOweek");

                entity.Property(e => e.TheIsoyear).HasColumnName("TheISOYear");

                entity.Property(e => e.TheLastOfMonth).HasColumnType("date");

                entity.Property(e => e.TheLastOfNextMonth).HasColumnType("date");

                entity.Property(e => e.TheLastOfQuarter).HasColumnType("date");

                entity.Property(e => e.TheLastOfWeek).HasColumnType("date");

                entity.Property(e => e.TheLastOfYear).HasColumnType("date");

                entity.Property(e => e.TheMonthName).HasMaxLength(30);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmplNo);

                //entity.Property(e => e.AddressLine1).HasMaxLength(40);

                //entity.Property(e => e.AddressLine2).HasMaxLength(40);

                //entity.Property(e => e.AddressLine3).HasMaxLength(40);

                //entity.Property(e => e.AddressLine4).HasMaxLength(40);

                //entity.Property(e => e.Ademail)
                //    .HasMaxLength(50)
                //    .IsUnicode(false)
                //    .HasColumnName("ADEmail");

                //entity.Property(e => e.AdminOrCraft)
                //    .HasMaxLength(10)
                //    .IsUnicode(false);

                //entity.Property(e => e.Aduser)
                //    .HasMaxLength(20)
                //    .IsUnicode(false)
                //    .HasColumnName("ADUser");

                //entity.Property(e => e.City).HasMaxLength(25);

                //entity.Property(e => e.Company).HasMaxLength(5);

                //entity.Property(e => e.CompanyName)
                //    .HasMaxLength(30)
                //    .IsUnicode(false);

                //entity.Property(e => e.CompanyNameNo)
                //    .HasMaxLength(30)
                //    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                //entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.HomeCostCenter).HasMaxLength(12);

                entity.Property(e => e.HomeCostCenterDesc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                //entity.Property(e => e.HourlySalary)
                //    .HasMaxLength(1)
                //    .IsUnicode(false);

                //entity.Property(e => e.JobDescription)
                //    .HasMaxLength(30)
                //    .IsUnicode(false);

                //entity.Property(e => e.JobStep).HasMaxLength(4);

                //entity.Property(e => e.JobStepDesc).HasMaxLength(4);

                //entity.Property(e => e.JobType).HasMaxLength(6);

                //entity.Property(e => e.JobTypeStepDescNo)
                //    .HasMaxLength(80)
                //    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.MiddleName).HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(40);

                //entity.Property(e => e.RehireDate).HasColumnType("date");

                //entity.Property(e => e.State).HasMaxLength(3);

                //entity.Property(e => e.TerminationDate).HasColumnType("date");

                //entity.Property(e => e.ZipCode).HasMaxLength(12);
            });

            modelBuilder.Entity<EmployeeEquipment>(entity =>
            {
                entity.HasKey(e => e.UnitNo);

                entity.ToTable("Employee_Equipment");

                entity.Property(e => e.UnitNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AcquiredDate).HasColumnType("date");

                entity.Property(e => e.AdrbookNo).HasColumnName("ADRBookNo");

                entity.Property(e => e.Desc1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Desc2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EffDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ModelNo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeManager>(entity =>
            {
                entity.HasKey(e => e.EmplId);

                entity.ToTable("Employee_Managers");

                entity.Property(e => e.EmplId).ValueGeneratedNever();

                entity.Property(e => e.EmplName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeePhone>(entity =>
            {
                entity.HasKey(e => e.EmplNo);

                entity.ToTable("Employee_Phones");

                entity.Property(e => e.EmplNo).ValueGeneratedNever();

                entity.Property(e => e.CellAreaCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CellPhoneNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact1AreaCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Contact1PhoneNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact2AreaCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Contact2PhoneNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact3AreaCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Contact3PhoneNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyAreaCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyPhoneNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAreaCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhoneNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeesActive>(entity =>
            {
                entity.HasKey(e => e.EmplNo);

                entity.ToTable("Employees_Active");

                entity.HasIndex(e => e.LastName, "idx_LastName");

                entity.Property(e => e.EmplNo).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ademail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADEmail");

                entity.Property(e => e.AdminOrCraft)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Aduser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADUser");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyNameNo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionDistrictDesc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.HomeCostCenter)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HomeCostCenterDesc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HomeCostCenterTrimmed)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HourlySalary)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobStep)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.JobStepDesc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.JobTypeStepDescNo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProfitServiceCenter)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RehireDate).HasColumnType("date");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.HasKey(e => e.JobCodeStep);

                entity.ToTable("Job_Titles");

                entity.Property(e => e.JobCodeStep)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.JobCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.JobStep)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitleDescription)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paytype>(entity =>
            {
                entity.HasKey(e => e.Paytypecode)
                    .HasName("PK_Timecard_Paytype");

                entity.ToTable("Paytype");

                entity.Property(e => e.Paytypecode)
                    .ValueGeneratedNever()
                    .HasColumnName("PAYTYPECODE");

                entity.Property(e => e.Paytypedescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYTYPEDESCRIPTION");
            });

            modelBuilder.Entity<ProjectsActive>(entity =>
            {
                entity.HasKey(e => e.CostCenterTrimmed);

                entity.ToTable("Projects_Active");

                entity.Property(e => e.CostCenterTrimmed)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActualComplete).HasColumnType("date");

                entity.Property(e => e.ActualStart).HasColumnType("date");

                entity.Property(e => e.CostCenter)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedComplete).HasColumnType("date");

                entity.Property(e => e.PlannedStart).HasColumnType("date");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateKey);

                entity.Property(e => e.StateId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("StateID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subledger>(entity =>
            {
                entity.HasKey(e => new { e.SubledgerType, e.SubledgerValue })
                    .HasName("PK_Subledger");

                entity.HasIndex(e => e.SubledgerType, "IX_Subledgers_SubledgerType");

                entity.Property(e => e.SubledgerType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SubledgerValue)
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.SubledgerDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subledgetype>(entity =>
            {
                entity.HasKey(e => e.Subledgertypecode)
                    .HasName("PK_Timecard_Subledgetype");

                entity.ToTable("Subledgetype");

                entity.Property(e => e.Subledgertypecode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUBLEDGERTYPECODE");

                entity.Property(e => e.Subledgertype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBLEDGERTYPE");
            });

            modelBuilder.Entity<VAdmPermissionsByDatabaseRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_adm_PermissionsByDatabaseRole");

                entity.Property(e => e.DatabaseRoleName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.DatabaseUserName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<VAdmPermissionsByObject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_adm_PermissionsByObject");

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ObjectType)
                    .HasMaxLength(60)
                    .UseCollation("Latin1_General_CI_AS_KS_WS");

                entity.Property(e => e.ObjectTypeCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .UseCollation("Latin1_General_CI_AS_KS_WS");

                entity.Property(e => e.PermissionAssignedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Permission_Assigned_Date");

                entity.Property(e => e.PermissionName)
                    .HasMaxLength(128)
                    .HasColumnName("permission_name")
                    .UseCollation("Latin1_General_CI_AS_KS_WS");

                entity.Property(e => e.Schema)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("schema");

                entity.Property(e => e.StateDesc)
                    .HasMaxLength(60)
                    .HasColumnName("state_desc")
                    .UseCollation("Latin1_General_CI_AS_KS_WS");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserType)
                    .HasMaxLength(60)
                    .UseCollation("Latin1_General_CI_AS_KS_WS");
            });

            modelBuilder.Entity<VCostCodesDropdown>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_CostCodes_Dropdown");

                entity.Property(e => e.CostCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CostCodeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayField)
                    .HasMaxLength(111)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VCostCodesLevel7Tibc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_CostCodesLevel7_TIBC");

                entity.Property(e => e.CostCenterDescription).HasMaxLength(30);

                entity.Property(e => e.CostCode)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DivisionCode).HasMaxLength(3);

                entity.Property(e => e.DivisionDesc).HasMaxLength(30);

                entity.Property(e => e.GroupCode).HasMaxLength(3);

                entity.Property(e => e.GroupDesc).HasMaxLength(30);

                entity.Property(e => e.RegionCode).HasMaxLength(3);

                entity.Property(e => e.RegionDesc).HasMaxLength(30);

                entity.Property(e => e.TypeCode).HasMaxLength(3);

                entity.Property(e => e.TypeDesc).HasMaxLength(30);
            });

            modelBuilder.Entity<VCsicodedropdown>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_CSICODEDropdown");

                entity.Property(e => e.Csilevel).HasColumnName("CSILEVEL");

                entity.Property(e => e.Displayfield)
                    .HasMaxLength(273)
                    .HasColumnName("DISPLAYFIELD");

                entity.Property(e => e.Isheading).HasColumnName("ISHEADING");

                entity.Property(e => e.Parentuniqueid).HasColumnName("PARENTUNIQUEID");

                entity.Property(e => e.Uniqueid).HasColumnName("UNIQUEID");
            });

            modelBuilder.Entity<VDistinctCostCentersTrimmed>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_DistinctCostCentersTrimmed");

                entity.Property(e => e.CostCenterDescription)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterTrimmed)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayField)
                    .HasMaxLength(56)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VDistinctCostCentersTrimmedType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_DistinctCostCentersTrimmed_Type");

                entity.Property(e => e.CostCenterTrimmed)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CostType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CostTypeDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayField)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VDistinctCostCentersTrimmedTypeCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_DistinctCostCentersTrimmed_Type_Code");

                entity.Property(e => e.CostCenterTrimmed)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CostCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CostCodeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayField)
                    .HasMaxLength(112)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VDistinctCostCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_DistinctCostCode");

                entity.Property(e => e.CostCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VDistinctCostTypeCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_DistinctCostType_Code");

                entity.Property(e => e.CostCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CostType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VEmpIter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmpIter");

                entity.Property(e => e.AddressLine1).HasMaxLength(40);

                entity.Property(e => e.AddressLine2).HasMaxLength(40);

                entity.Property(e => e.AddressLine3).HasMaxLength(40);

                entity.Property(e => e.AddressLine4).HasMaxLength(40);

                entity.Property(e => e.Ademail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADEmail");

                entity.Property(e => e.AdminOrCraft)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Aduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADUser");

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyNameNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayField).HasMaxLength(93);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.HomeCostCenter).HasMaxLength(12);

                entity.Property(e => e.HomeCostCenterDesc)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HourlySalary)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobStep).HasMaxLength(4);

                entity.Property(e => e.JobStepDesc).HasMaxLength(4);

                entity.Property(e => e.JobType).HasMaxLength(6);

                entity.Property(e => e.JobTypeStepDescNo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.MiddleName).HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.RehireDate).HasColumnType("date");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.ZipCode).HasMaxLength(12);
            });

            modelBuilder.Entity<VEmpIterDistinct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmpIterDistinct");
            });

            modelBuilder.Entity<VFullAccountNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_FullAccountNumbers");

                entity.Property(e => e.DisplayField)
                    .HasMaxLength(205)
                    .IsUnicode(false);

                entity.Property(e => e.FullAccountDescription)
                    .HasMaxLength(176)
                    .IsUnicode(false);

                entity.Property(e => e.FullAccountNumber)
                    .IsRequired()
                    .HasMaxLength(28)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VManagerId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Manager_IDs");
            });

            modelBuilder.Entity<VPayTypeDropdown>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_PayType_Dropdown");

                entity.Property(e => e.Paytypecode).HasColumnName("PAYTYPECODE");

                entity.Property(e => e.Paytypedescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYTYPEDESCRIPTION");

                entity.Property(e => e.Paytypedisplayfield)
                    .HasMaxLength(308)
                    .IsUnicode(false)
                    .HasColumnName("PAYTYPEDISPLAYFIELD");
            });

            modelBuilder.Entity<VSubledgerDropDown>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_SubledgerDropDown");

                entity.Property(e => e.DisplayField)
                    .HasMaxLength(126)
                    .IsUnicode(false);

                entity.Property(e => e.SearchField)
                    .HasMaxLength(123)
                    .IsUnicode(false);

                entity.Property(e => e.SubledgerDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubledgerType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SubledgerValue)
                    .HasMaxLength(23)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VSubledgertypeDropdown>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_Subledgertype_Dropdown");

                entity.Property(e => e.Subledgerdisplayfield)
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasColumnName("SUBLEDGERDISPLAYFIELD");

                entity.Property(e => e.Subledgertype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBLEDGERTYPE");

                entity.Property(e => e.Subledgertypecode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUBLEDGERTYPECODE");
            });

            modelBuilder.Entity<VTimeCardDateDimension>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_TimeCardDateDimension");

                entity.Property(e => e.DayNameDate).HasMaxLength(14);

                entity.Property(e => e.Style101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheDate).HasColumnType("date");

                entity.Property(e => e.TheDayName).HasMaxLength(30);

                entity.Property(e => e.TheLastOfWeek).HasColumnType("date");
            });

            modelBuilder.Entity<VWeekendingDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WeekendingDates");

                entity.Property(e => e.Has53Isoweeks).HasColumnName("Has53ISOWeeks");

                entity.Property(e => e.Mmyyyy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MMYYYY")
                    .IsFixedLength(true);

                entity.Property(e => e.Style101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style112)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheDate).HasColumnType("date");

                entity.Property(e => e.TheDayName).HasMaxLength(30);

                entity.Property(e => e.TheDaySuffix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheFirstOfMonth).HasColumnType("date");

                entity.Property(e => e.TheFirstOfNextMonth).HasColumnType("date");

                entity.Property(e => e.TheFirstOfQuarter).HasColumnType("date");

                entity.Property(e => e.TheFirstOfWeek).HasColumnType("date");

                entity.Property(e => e.TheFirstOfYear).HasColumnType("date");

                entity.Property(e => e.TheIsoweek).HasColumnName("TheISOweek");

                entity.Property(e => e.TheIsoyear).HasColumnName("TheISOYear");

                entity.Property(e => e.TheLastOfMonth).HasColumnType("date");

                entity.Property(e => e.TheLastOfNextMonth).HasColumnType("date");

                entity.Property(e => e.TheLastOfQuarter).HasColumnType("date");

                entity.Property(e => e.TheLastOfWeek).HasColumnType("date");

                entity.Property(e => e.TheLastOfYear).HasColumnType("date");

                entity.Property(e => e.TheMonthName).HasMaxLength(30);
            });

            modelBuilder.Entity<VWeekendingDatesPayroll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WeekendingDates_Payroll");

                entity.Property(e => e.Has53Isoweeks).HasColumnName("Has53ISOWeeks");

                entity.Property(e => e.Mmyyyy)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MMYYYY")
                    .IsFixedLength(true);

                entity.Property(e => e.Style101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style103)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style112)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Style120)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheDate).HasColumnType("date");

                entity.Property(e => e.TheDayName).HasMaxLength(30);

                entity.Property(e => e.TheDaySuffix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TheFirstOfMonth).HasColumnType("date");

                entity.Property(e => e.TheFirstOfNextMonth).HasColumnType("date");

                entity.Property(e => e.TheFirstOfQuarter).HasColumnType("date");

                entity.Property(e => e.TheFirstOfWeek).HasColumnType("date");

                entity.Property(e => e.TheFirstOfYear).HasColumnType("date");

                entity.Property(e => e.TheIsoweek).HasColumnName("TheISOweek");

                entity.Property(e => e.TheIsoyear).HasColumnName("TheISOYear");

                entity.Property(e => e.TheLastOfMonth).HasColumnType("date");

                entity.Property(e => e.TheLastOfNextMonth).HasColumnType("date");

                entity.Property(e => e.TheLastOfQuarter).HasColumnType("date");

                entity.Property(e => e.TheLastOfWeek).HasColumnType("date");

                entity.Property(e => e.TheLastOfYear).HasColumnType("date");

                entity.Property(e => e.TheMonthName).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
