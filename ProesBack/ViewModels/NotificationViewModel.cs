using Dropbox.Api.TeamLog;
using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ProesBack.ViewModels
{
    public class NotificationViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public int SenderId { get; set; }
        public DateTime Date { get; set; }
        public NotificationType Type { get; set; }
    }
}
