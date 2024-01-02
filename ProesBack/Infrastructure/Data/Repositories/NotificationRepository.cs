using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository 
    {
        private readonly ProesContext _dbContext;
        public NotificationRepository(ProesContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
