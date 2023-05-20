using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MappyUserApi.Models
{
    public class RegisterUserModel
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}