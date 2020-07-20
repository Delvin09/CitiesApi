using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly DbSet<T> _entities;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _entities = databaseContext.Set<T>();
        }

        public async Task<T> Add(T model)
        {
            return (await _entities.AddAsync(model)).Entity;
        }

        public void Delete(T model)
        {
            _entities.Remove(model);
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public void Update(T model)
        {
            _entities.Update(model);
        }

        public async Task SaveChanges()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel)
        {
            return _databaseContext.BeginTransaction(isolationLevel);
        }
    }
}
