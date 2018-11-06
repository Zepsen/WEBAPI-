using System;
using DAL.Interfaces;

namespace DAL.Models
{
    public class CompanyDescriptions : IEntityBase
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; }


        public Company Company { get; set; }
    }
}