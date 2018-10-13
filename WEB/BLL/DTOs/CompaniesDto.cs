using BLL.Interfaces;
using DAL.Models;

namespace BLL.DTOs
{
    /// <summary>
    /// <see cref="Companies"/>see
    /// </summary>
    public class CompaniesDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Test { get; set; }
        public string Code { get; set; }


        
    }
}