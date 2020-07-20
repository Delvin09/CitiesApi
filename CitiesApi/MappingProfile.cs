using AutoMapper;
using CitiesApi.DAL.Model;
using CitiesApi.Dtos;

namespace CitiesApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
