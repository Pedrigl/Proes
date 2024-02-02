using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        private readonly ProesContext _dbContext;

        public UserRepository(ProesContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByLoginId(long loginId)
        {
            return _dbContext.Users.FirstOrDefault(x => x.LoginId == loginId);
        }

    }
}
