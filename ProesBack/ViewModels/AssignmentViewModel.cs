using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class AssignmentViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo Title é obrigatório")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo CourseId é obrigatório")]
        public long CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CorrectionDate { get; set; }
        public decimal? Grade { get; set; }
    }
}
