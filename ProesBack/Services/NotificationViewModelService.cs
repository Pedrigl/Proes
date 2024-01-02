using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Services
{
    public class NotificationViewModelService : INotificationViewModelService
    {
        public readonly INotificationRepository _notificationRepository;
        public readonly IMapper _mapper;

        public NotificationViewModelService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public void DeleteNotification(int id)
        {
            _notificationRepository.Delete(id);
            _notificationRepository.Save();
        }

        public List<NotificationViewModel> GetAllNotifications()
        {
            var notifications = _notificationRepository.GetAll();
            return _mapper.Map<List<NotificationViewModel>>(notifications);
        }

        public NotificationViewModel GetNotification(int id)
        {
            var notification = _notificationRepository.Get(id);
            return _mapper.Map<NotificationViewModel>(notification);
        }

        public void InsertNotification(NotificationViewModel notificationViewModel)
        {
            var notification = _mapper.Map<Notification>(notificationViewModel);
            _notificationRepository.Insert(notification);
            _notificationRepository.Save();
        }

        public void UpdateNotification(NotificationViewModel notificationViewModel)
        {
            var notification = _mapper.Map<Notification>(notificationViewModel);
            _notificationRepository.Update(notification);
            _notificationRepository.Save();
        }
    }
}
