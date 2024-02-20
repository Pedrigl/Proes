using Microsoft.AspNetCore.Identity;
using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        [SwaggerSchema(ReadOnly = true)]
        public long Id { get; set; }

        public long UserId { get; set; }

        [Required(ErrorMessage = "O campo Usuario é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Usuario deve ter no máximo 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Password { get; set; }

        public string Token { get; set; }

        public DateTime TokenExpiration { get; set; }

        [Required(ErrorMessage = "O campo UserType é obrigatório")]
        public UserType UserType { get; set; }
    }
}
