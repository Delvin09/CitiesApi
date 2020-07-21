using CitiesApi.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public async Task<User> AddOrUpdateBy(User user)
        {
            using (var transaction = await BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                var existUser = await GetAll().FirstOrDefaultAsync(u => u.CityId == user.CityId && u.Name == user.Name);
                if (existUser == null)
                    existUser = await Add(user);
                else if (existUser.Value != user.Value)
                    existUser.Value = user.Value;

                await SaveChanges();
                await transaction.CommitAsync();
                return existUser;
            }
        }
    }
}
