using ProesBack.Domain.Enums;

namespace ProesBack.Domain.Entities
{
    public class Login : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string? Token { get; set; }

        public int? TokenExpiration { get; set; }

        public UserType UserType { get; set; }
    }
}
