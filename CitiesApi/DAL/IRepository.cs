using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.DAL
{
    public interface IRepository<T>
    {
        Task<T> Add(T model);
        ValueTask<T> AddOrUpdate(T model);
        void Update(T model);
        void Delete(T model);
        IQueryable<T> Get();
        Task SaveChanges();
    }
}
