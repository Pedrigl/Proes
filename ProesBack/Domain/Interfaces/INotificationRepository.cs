using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAll();
        Notification Get(int id);
        void Insert(Notification notification);
        void Update(Notification notification);
        void Delete(int id);
        void Save();
    }
}
