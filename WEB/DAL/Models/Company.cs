using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace DAL.Models
{
    public class Company : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Test { get; set; }

        public List<CompanyDescriptions> CompanyDescriptions { get; set; }
    }
}