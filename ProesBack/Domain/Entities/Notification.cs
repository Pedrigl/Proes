using ProesBack.Domain.Enums;

namespace ProesBack.Domain.Entities
{
    public class Notification : BaseModel
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public int SenderId { get; set; }
        public DateTime Date { get; set; }
        public NotificationType Type { get; set; }
        
        //TODO: DESCOBRIR COMO A NOTIFICAÇÃO VAI SE RELACIONAR COM SEU SENDER, CRIAR SEU VIEW MODEL E SEU MAP, E CRIAR SUA TABELA NO BANCO DE DADOS

    }
}
