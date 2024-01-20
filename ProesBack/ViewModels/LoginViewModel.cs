using Microsoft.AspNetCore.Identity;
using ProesBack.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public long Id { get; set; }

        [Display(Name = "id de Usuario")]
        public long UserId { get; set; }

        [Display(Name ="Usuario")]
        [Required(ErrorMessage = "O campo Usuario é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Usuario deve ter no máximo 50 caracteres")]
        public string Username { get; set; }

        [Display(Name = "Token")]
        public string Token { get; set; }

        [Display(Name = "DataDeExpiracaoDoToken")]
        public DateTime TokenExpiration { get; set; }

        [Display(Name = "TipoDeUsuario")]
        [Required(ErrorMessage = "O campo UserType é obrigatório")]
        public UserType UserType { get; set; }
    }
}
