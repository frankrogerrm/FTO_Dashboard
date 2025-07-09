using System;
using ftodashboard.Data;
using ftodashboard.Models;

namespace ftodashboard.Classes
{
    public static class Logger
    {
        public static string User { get; set; } = "";
        public static LoggingContext Db { get; set; } = new LoggingContext();

        public static void Startup(string user, LoggingContext dbContext)
        {
            User = user;
            Db = dbContext;
        }
        public static void LogEvent(int Id, string Event, string OldValue, string NewValue)
        {
            Log logItem = new()
            {
                TemplateId = Id,
                Event = Event,
                OldValue = OldValue,
                NewValue = NewValue,
                Date = DateTime.Now,
                User = User
            };


            Db.Logs.Add(logItem);

            Db.SaveChanges();
        }
    }
}
