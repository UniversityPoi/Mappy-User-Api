using System.ComponentModel.DataAnnotations;

namespace MappyUserApi.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}