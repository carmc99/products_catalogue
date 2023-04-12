﻿using MediatR;
using products_catalogue.Application.Category.Command.Request;
using products_catalogue.Domain.ViewModels;

namespace products_catalogue.Application.Product.Command.Request
{
    public class AddProductRequest : IRequest<ResponseViewModel<Domain.Models.Product>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AddCategoryRequest Category { get; set; }
        public string Image { get; set; }
    }
}