using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ProesBack.ViewModels
{
    public class CourseViewModel
    {
        [SwaggerSchema(ReadOnly =true)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long TeacherID { get; set; }
        public DateTime CreationDate { get; set; }
        public Semesters Semester { get; set; }
    }
}
