using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Companies : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Test { get; set; }

        public ICollection<CompanyDescriptions> Descriptions { get; set; }
        

    }
}