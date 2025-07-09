using ftodashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace ftodashboard.Data
{
    public class TimeSheetAppContext : DbContext
    {
        public virtual DbSet<VFTODashboardFTOByMonth> V_FTODashboard_FTOByMonth { get; set; }

        public TimeSheetAppContext(DbContextOptions<TimeSheetAppContext> options)
       : base(options)
        { }

        public TimeSheetAppContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VFTODashboardFTOByMonth>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
