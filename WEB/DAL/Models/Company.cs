using System;

namespace DAL.Models
{
    public class Company : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Test { get; set; }

    }
}