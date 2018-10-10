using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using DAL.Models;
using HashidsNet;
using WEB.Infrastructure.Hashers;

namespace WEB.Infrastructure.Automapper
{
    public class CompaniesMapper : Profile
    {
        private readonly Hashids _hash = HasherHelper.GetInstance;

        public CompaniesMapper()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.Id, m => m.MapFrom(e => _hash.Encode(e.Id)));
                //.ForMember(d => d.Test, m => m.MapFrom(e => RoleHelper.Role != "Admin" ? e.Test : null)); 

            CreateMap<CompanyDto, Company>()
                .ForMember(e => e.Id, m => m.MapFrom(d => _hash.Decode(d.Id)));
        }
    }

}