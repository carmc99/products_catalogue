using MediatR;
using products_catalogue.Domain.ViewModels;
using System;

namespace products_catalogue.Application.Category.Command.Request
{
    public class RemoveCategoryRequest : IRequest<ResponseViewModel<Guid>>
    {
        public Guid Id { get; set; }
    }
}