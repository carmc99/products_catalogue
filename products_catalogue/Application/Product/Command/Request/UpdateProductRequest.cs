using products_catalogue.Application.Category.Command.Request;
using System;

namespace products_catalogue.Application.Product.Command.Request
{
    public class UpdateProductRequest
    {
        internal Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AddCategoryRequest Category { get; set; }
        public string Image { get; set; }
    }
}