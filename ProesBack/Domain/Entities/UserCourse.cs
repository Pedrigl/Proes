namespace ProesBack.Domain.Entities
{
    public class UserCourse : BaseModel
    {
        public long UserId { get; set; }
        public long CourseId { get; set; }
        public decimal Grade { get; set; }
        public decimal Attendance { get; set; }
        public bool IsDone { get; set;}

    }
}
