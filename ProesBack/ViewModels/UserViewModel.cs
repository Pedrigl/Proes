using ProesBack.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class UserViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo UserId é obrigatório")]
        public int UserId { get; set; }

        [Display(Name = "NomeDeUsuario")]
        [Required(ErrorMessage = "O campo UserName é obrigatório")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [Display(Name = "TipoDeUsuario")]
        [Required(ErrorMessage = "O campo UserType é obrigatório")]
        public UserType UserType { get; set; }

        [Display(Name = "DataDeNascimento")]
        [Required(ErrorMessage = "O campo BirthDate é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "FotoDePerfil")]
        public string? UserPictureUrl { get; set; }



    }
}
