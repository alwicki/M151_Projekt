using System.Collections.Generic;

namespace API.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public string TargetTopic { get; set; }
        public int TargetId { get; set; }
        public User ReportingUser { get; set; }
        public User ReportedUser {get; set;}
    }
}