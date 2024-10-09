using System.ComponentModel.DataAnnotations;

namespace SocialMediaExample.Entities
{
    public class User
    {
        public int IdUser { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
