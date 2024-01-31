using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;

namespace ProesBack.Infrastructure.Data.Repositories
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        private readonly ProesContext _dbContext;

        public AssignmentRepository(ProesContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
