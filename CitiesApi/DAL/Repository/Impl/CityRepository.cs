using CitiesApi.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitiesApi.DAL.Repository
{
    internal class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public Task<City> GetCityByName(string name) => GetAll().FirstOrDefaultAsync(c => c.Name == name);
    }
}
