using System.ComponentModel.DataAnnotations;

namespace MappyUserApi.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}