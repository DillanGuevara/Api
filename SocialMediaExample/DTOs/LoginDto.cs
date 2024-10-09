using SocialMediaExample.Enumerations;

namespace SocialMediaExample.DTOs
{
    public class LoginDto
    {
        public required string User { get; set; }
        public required string UserName { get; set; }
        public string Username { get; internal set; }
        public required string Password { get; set; }
        public RoleType Role { get; set; }
        public int IdLogin { get; set; }
    }
}