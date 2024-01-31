using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class UserCourseRepository : GenericRepository<UserCourse> , IUserCoursesRepository
    {
        private readonly ProesContext _dbContext;

        public UserCourseRepository(ProesContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
