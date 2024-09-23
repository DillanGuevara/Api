using SocialMedia.Core.Enumerations;

namespace SocialMedia.Core.Entities
{
    public class Login : BaseEntity
    {
        public int IdSecurity { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
}
