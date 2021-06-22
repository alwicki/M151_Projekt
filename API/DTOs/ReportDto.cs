using API.Enums;

namespace API.DTOs
{
    public class ReportDto
    {
        public int TargetId { get; set; }
        public string TargetTopic { get; set; }

        public int ReportedUser { get; set; }
        public string ReportedUserName { get; set; }

        public int ReportedUserPenalty { get; set; }

        public int ReportingUser { get; set; }
        public string ReportingUserName { get; set; }

        public int ReportingUserPenalty { get; set; }
    }
}
