using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace WEB.Infrastructure.Automapper
{
    public class UsersMapper : Profile
    {
        public UsersMapper()
        {
            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();
        }
    }

}