using ProesBack.Domain.Enums;

namespace ProesBack.Domain.Entities
{
    public class Course : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long TeacherId { get; set; }
        public DateTime CreationDate { get; set; }
        public Semesters Semester { get; set; }
    }
}
