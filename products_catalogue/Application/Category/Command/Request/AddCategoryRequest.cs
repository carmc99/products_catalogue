using MediatR;
using products_catalogue.Domain.ViewModels;

namespace products_catalogue.Application.Category.Command.Request
{
    public class AddCategoryRequest : IRequest<ResponseViewModel<Domain.Models.Category>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}