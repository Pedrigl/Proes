using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class CourseViewModel
    {
        [SwaggerSchema(ReadOnly =true)]
        [Key]
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo Title é obrigatório")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo TeacherId é obrigatório")]
        public long TeacherId { get; set; }
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "O campo Semester é obrigatório")]
        public Semesters Semester { get; set; }
    }
}
