using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using HashidsNet;

namespace WEB.Infrastructure.Automapper
{
    public class UsersMapper : Profile
    {
        private readonly Hashids _hash = new Hashids(nameof(UsersDto));

        public UsersMapper()
        {
            CreateMap<Users, UsersDto>()
                .ForMember(d => d.Id, m => m.MapFrom(e => _hash.Encode(e.Id)));

            CreateMap<UsersDto, Users>()
                .ForMember(e => e.Id, m => m.MapFrom(d => _hash.Decode(d.Id)));
        }
    }

}