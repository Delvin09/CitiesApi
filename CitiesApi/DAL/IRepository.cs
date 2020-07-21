using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CitiesApi.DAL
{
    public interface IRepository<T> : IDisposable
    {
        Task<T> Add(T model);
        void Delete(T model);
        IQueryable<T> GetAll();
        Task SaveChanges();

        Task<IDbContextTransaction> BeginTransaction(System.Data.IsolationLevel isolationLevel);
    }
}
