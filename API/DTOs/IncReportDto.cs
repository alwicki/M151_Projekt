using API.Enums;

namespace API.DTOs
{
    public class IncReportDto
    {
        public int TargetId { get; set; }
        public string TargetTopic { get; set; }

        public int ReportedUser {get; set;}
    }
}