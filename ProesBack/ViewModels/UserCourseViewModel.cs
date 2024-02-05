using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class UserCourseViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo UserId é obrigatório")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "O campo CourseId é obrigatório")]
        public long CourseId { get; set; }
        public decimal Grade { get; set; }
        public decimal Attendance { get; set; }
        public bool IsDone { get; set;}

    }
}
