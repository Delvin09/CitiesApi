using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesApi.DAL
{
    public interface IDatabaseContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel);
        void Dispose();
    }
}
