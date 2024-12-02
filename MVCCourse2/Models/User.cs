using System.ComponentModel.DataAnnotations;

namespace MVCCourse2.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
