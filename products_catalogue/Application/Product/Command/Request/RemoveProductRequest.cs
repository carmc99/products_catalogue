using MediatR;
using products_catalogue.Domain.ViewModels;
using System;

namespace products_catalogue.Application.Product.Command.Request
{
    public class RemoveProductRequest : IRequest<ResponseViewModel<Guid>>
    {
        public Guid Id { get; set; }
    }
}