using ProesBack.Domain.Enums;

namespace ProesBack.Domain.Entities
{
    public class Login : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; internal set; }

        public int TokenExpiration { get; internal set; }

        public UserType UserType { get; internal set; }
    }
}
