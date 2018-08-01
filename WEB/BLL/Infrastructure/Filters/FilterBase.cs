namespace BLL.Infrastructure.Filters
{
    public class FilterBase
    {
        public string Query { get; set; }

        public string Fields { get; set; }

        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
    
}