namespace ProesBack.ViewModels
{
    public class UserCourseViewModel
    {
        public long UserId { get; set; }
        public long CourseId { get; set; }
        public decimal Grade { get; set; }
        public decimal Attendance { get; set; }
        public bool IsDone { get; set;}

    }
}
