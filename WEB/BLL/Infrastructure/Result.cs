using System.Collections.Generic;

namespace BLL.Infrastructure
{
    public class Result<TDto>
    {
        public int Total { get; set; } = -1;
        public List<TDto> Data { get; set; }
        public bool Pagination { get; set; }
    }
}