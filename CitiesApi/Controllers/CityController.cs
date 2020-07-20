using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CitiesApi.DAL.Model;
using CitiesApi.DAL.Repository;
using CitiesApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CitiesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CityController(ICityRepository cityRepository, IUserRepository userRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET <CityController>/Moscow
        [HttpGet("{cityName}")]
        public async Task<IActionResult> Get(string cityName)
        {
            var city = await _cityRepository.GetCityByName(cityName);
            if (city == null)
                return BadRequest();
            return Ok(city.Id);
        }

        // POST <CityController>
        [HttpPost]
        public void Post([FromBody] UserModel user)
        {
            var userEnity = _mapper.Map<User>(user);
            _userRepository.AddOrUpdateBy(userEnity);
        }
    }
}
