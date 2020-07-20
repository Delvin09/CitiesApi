using CitiesApi.DAL.Model;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    public interface ICityRepository : IRepository<City>
    {
        Task<City> GetCityByName(string name);
    }
}
