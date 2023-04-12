using MediatR;
using products_catalogue.Domain.ViewModels;
using System.Collections.Generic;

namespace products_catalogue.Application.Product.Query.Request
{
    public class GetAllProductsRequest : IRequest<ResponseViewModel<IEnumerable<Domain.Models.Product>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }
    }
}