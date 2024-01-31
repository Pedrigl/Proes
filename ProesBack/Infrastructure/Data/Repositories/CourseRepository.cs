using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        private readonly ProesContext _dbContext;

        public CourseRepository(ProesContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
