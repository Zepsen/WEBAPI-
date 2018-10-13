using System;

namespace DAL.Models
{
    public class CompanyDescriptions : EntityBase<int>
    {
        public int CompanyId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; }


        public Companies Company { get; set; }
    }
}