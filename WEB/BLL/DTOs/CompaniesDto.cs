﻿using BLL.Interfaces;

namespace BLL.DTOs
{
    public class CompaniesDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}