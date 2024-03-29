﻿using Dropbox.Api.TeamLog;
using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProesBack.ViewModels
{
    public class NotificationViewModel
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public long Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }

        [Required(ErrorMessage = "O campo SenderId é obrigatório")]
        public long SenderId { get; set; }

        [Required(ErrorMessage = "O campo ReceiverId é obrigatório")]
        public long ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public NotificationType Type { get; set; }
    }
}
