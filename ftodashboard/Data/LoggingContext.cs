using Microsoft.EntityFrameworkCore;
using ftodashboard.Models;

#nullable disable
namespace ftodashboard.Data
{
    public class LoggingContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public LoggingContext(DbContextOptions<LoggingContext> options)
       : base(options)
        { }

        public LoggingContext()
        {
        }
    }
}
