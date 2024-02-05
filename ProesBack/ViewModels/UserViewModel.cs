using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class UserViewModel
    {
        [Key]
        [Required(ErrorMessage = "O campo UserId é obrigatório")]
        [SwaggerSchema(ReadOnly = true)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo loginId é obrigatório")]
        public long LoginId { get; set; }

        [Required(ErrorMessage = "O campo Name é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string? PictureUrl { get; set; }

        public Semesters Semester { get; set; }

    }
}
