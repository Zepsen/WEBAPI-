using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using HashidsNet;

namespace WEB.Infrastructure.Automapper
{
    public class CompaniesMapper : Profile
    {
        private readonly Hashids _hash = new Hashids(nameof(CompaniesDto));

        public CompaniesMapper()
        {
            CreateMap<Companies, CompaniesDto>()
                .ForMember(d => d.Id, m => m.MapFrom(e => _hash.Encode(e.Id))); 
            CreateMap<CompaniesDto, Companies>()
                .ForMember(e => e.Id, m => m.MapFrom(d => _hash.Decode(d.Id)));
        }
    }

}