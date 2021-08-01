namespace API.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(string search, string Filter, string orderBy)
        {
            Search = search;
            OrderBy = orderBy;
        }

        public string Search { get; set; } = "";    
        public string Filter { get; set; } = "";
        public string OrderBy { get; set; } = "";
        
    }
}