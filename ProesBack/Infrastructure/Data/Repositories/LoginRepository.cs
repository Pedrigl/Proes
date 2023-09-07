using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        private readonly ProesContext _dbContext;
        public LoginRepository(ProesContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Login Login(string username, string password)
        {
            var login = _dbContext.Logins.FirstOrDefault(x=> x.Username == username && x.Password == password);
            return login;
        }

    }
}
