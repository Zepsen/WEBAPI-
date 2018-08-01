using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace WEB.Infrastructure.Automapper
{
    public class CompaniesMapper : Profile
    {
        public CompaniesMapper()
        {
            CreateMap<Companies, CompaniesDto>();
            CreateMap<CompaniesDto, Companies>();
        }
    }

}