using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MappyUserApi.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

    }
}