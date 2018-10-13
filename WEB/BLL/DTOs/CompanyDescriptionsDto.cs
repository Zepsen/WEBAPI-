using BLL.Interfaces;
using DAL.Models;

namespace BLL.DTOs
{
    /// <summary>
    /// <see cref="CompanyDescriptions"/>see
    /// </summary>
    public class CompanyDescriptionsDto : IDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}