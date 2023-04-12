using MediatR;
using products_catalogue.Domain.ViewModels;
using System;

namespace products_catalogue.Application.Product.Query.Request
{
    public class GetProductByIdRequest : IRequest<ResponseViewModel<Domain.Models.Product>>
    {
        public Guid Id { get; set; }
    }
}