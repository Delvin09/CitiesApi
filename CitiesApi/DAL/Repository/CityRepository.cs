using CitiesApi.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _databaseContext;

        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<T> Add(T model)
        {
            return (await _databaseContext.AddAsync(model)).Entity;
        }

        public ValueTask<T> AddOrUpdate(T model)
        {
            return _databaseContext.FindAsync<T>(model);
        }

        public void Delete(T model)
        {
            _databaseContext.Remove<T>(model);
        }

        public IQueryable<T> Get()
        {
            return _databaseContext.Set<T>();
        }

        public void Update(T model)
        {
            _databaseContext.Update<T>(model);
        }

        public async Task SaveChanges()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }

    public interface ICityRepository : IRepository<City>
    {
        Task<City> GetCityByName(string name);
    }

    internal class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public Task<City> GetCityByName(string name)
        {
            return _databaseContext.Cities.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
