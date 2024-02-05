using ProesBack.Domain.Enums;

namespace ProesBack.Domain.Entities
{
    public class Notification : BaseModel
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public NotificationType Type { get; set; }

    }
}
