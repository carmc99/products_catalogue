using products_catalogue.Domain.Models;

namespace products_catalogue.Domain.ViewModels
{
    public class ResponseViewModel<T>
    {
        public Metadata Metadata { get; set; }
        public T Payload { get; set; }
    }
}