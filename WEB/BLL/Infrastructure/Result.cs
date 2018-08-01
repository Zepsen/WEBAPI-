using System.Collections.Generic;

namespace BLL.Infrastructure
{
    public class Result<TDto>
    {
        public int Total { get; set; }
        public List<TDto> Data { get; set; }
    }
}