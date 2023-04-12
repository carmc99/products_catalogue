using MediatR;
using products_catalogue.Domain.ViewModels;
using System.Collections.Generic;

namespace products_catalogue.Application.Category.Query.Request
{
    public class GetAllCategoriesRequest : IRequest<ResponseViewModel<IEnumerable<Domain.Models.Category>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }
    }
}