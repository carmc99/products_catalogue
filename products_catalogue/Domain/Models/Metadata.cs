namespace products_catalogue.Domain.Models
{
    public class Metadata
    {
        public int StatusCode { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public int CurrentPageNumber { get; set; }
        public int CurrentPageSize { get; set; }
    }
}