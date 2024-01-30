namespace ProesBack.Domain.Entities
{
    public class Assignment : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CorrectionDate { get; set; }
        public int? Grade { get; set; }

    }
}
