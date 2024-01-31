namespace ProesBack.ViewModels
{
    public class AssignmentViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CorrectionDate { get; set; }
        public decimal? Grade { get; set; }
    }
}
