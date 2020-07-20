using CitiesApi.DAL.Model;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> AddOrUpdateBy(User user);
    }
}
