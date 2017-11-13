using AutoMapper;
using ApiClientCoreExample.BLL.DTO;
using ApiClientCoreExample.WEB.Models;
using ApiClientCoreExample.DAL.Entities;
namespace ApiClientCoreExample.WEB.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<RegisterModel, UserDTO>();
            CreateMap<UserDTO, RegisterModel>();

            CreateMap<DataDTO, CurrentStatsViewModel>();
        }
    }
}
