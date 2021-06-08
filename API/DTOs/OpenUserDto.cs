using API.Enums;

namespace API.DTOs
{
    public class OpenUserDto
    {
        public string UserId {get; set; }
        public string Username { get; set; }
        public EUserRole UserRole { get; set; }
    }
}