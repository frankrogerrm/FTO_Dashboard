using System;

namespace ftodashboard.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public int TemplateId { get; set; }
        public string Event { get; set; } = "";
        public string User { get; set; } = "";
        public DateTime Date { get; set; }
        public string OldValue { get; set; } = "";
        public string NewValue { get; set; } = "";

    }
}
