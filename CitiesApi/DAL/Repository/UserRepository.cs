using CitiesApi.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> AddOrUpdateBy(User user);
    }

    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public async Task<User> AddOrUpdateBy(User user)
        {
            var existUser = await _databaseContext.Users.FirstOrDefaultAsync(u => u.CityId == user.CityId && u.Name == user.Name);
            if (existUser.Value != user.Value)
            {
                existUser.Value = user.Value;
            }
            return existUser;
        }
    }
}
