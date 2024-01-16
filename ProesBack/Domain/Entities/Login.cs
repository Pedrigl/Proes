using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ProesBack.Domain.Entities
{
    public class Login : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Token { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public int? TokenExpiration { get; set; }

        public UserType UserType { get; set; }
    }
}
