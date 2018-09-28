using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using DAL.Models;
using HashidsNet;
using WEB.Infrastructure.Hashers;

namespace WEB.Infrastructure.Automapper
{
    public class UsersMapper : Profile
    {
        private readonly Hashids _hash = HasherHelper.GetInstance;

        public UsersMapper()
        {
            CreateMap<Users, UsersDto>()
                .ForMember(d => d.Id, m => m.MapFrom(e => _hash.Encode(e.Id)));

            CreateMap<UsersDto, Users>()
                .ForMember(e => e.Id, m => m.MapFrom(d => _hash.Decode(d.Id)));
        }
    }

}