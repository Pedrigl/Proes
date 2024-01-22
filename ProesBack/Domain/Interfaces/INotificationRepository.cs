using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAll();
        Notification Get(long id);
        void Insert(Notification notification);
        void Update(long entityId, Notification notification);
        void Delete(long id);
        void Save();
    }
}
