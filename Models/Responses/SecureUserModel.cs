namespace MappyUserApi.Models.Responses
{
    public class SecureUserModel
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }
    }
}