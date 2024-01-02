using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface INotificationViewModelService
    {
        NotificationViewModel GetNotification(int id);
        List<NotificationViewModel> GetAllNotifications();
        void InsertNotification(NotificationViewModel notificationViewModel);
        void UpdateNotification(NotificationViewModel notificationViewModel);
        void DeleteNotification(int id);
    }
}
