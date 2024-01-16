using Microsoft.EntityFrameworkCore;
using ProesBack.Domain.Entities;

namespace ProesBack.Infrastructure.Data.Common
{
    public class GenericRepository <T> where T : BaseModel
    {
        protected readonly ProesContext _dbContext;

        public GenericRepository(ProesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public T Get(long id)
        {
            var keyValues = new object[] { id };
            return _dbContext.Set<T>().Find(keyValues);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            var record = Get(entity.Id);
            _dbContext.Entry(record).CurrentValues.SetValues(entity);
        }

        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
