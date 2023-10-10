using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        private readonly ProesContext _context;

        public UserRepository(ProesContext context) : base(context)
        {
            _context = context;
        }

    }
}
