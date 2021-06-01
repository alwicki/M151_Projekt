using API.Enums;

namespace API.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public EUserRole UserRole { get; set; }
        public string Token { get; set; }
    }
}