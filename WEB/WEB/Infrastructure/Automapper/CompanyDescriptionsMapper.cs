﻿using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using HashidsNet;
using WEB.Infrastructure.Hashers;

namespace WEB.Infrastructure.Automapper
{
    public class CompanyDescriptionsMapper : Profile
    {
        private readonly Hashids _hash = HasherHelper.GetInstance;

        public CompanyDescriptionsMapper()
        {
            CreateMap<CompanyDescriptions, CompanyDescriptionsDto>()
                .ForMember(d => d.Id, m => m.MapFrom(e => _hash.Encode(e.Id))); 

            CreateMap<CompanyDescriptionsDto, CompanyDescriptions>()
                .ForMember(e => e.Id, m => m.MapFrom(d => _hash.Decode(d.Id)));
        }
    }

}