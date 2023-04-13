using MediatR;
using products_catalogue.Application.Product.Query.Request;
using products_catalogue.Domain.Enums;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using products_catalogue.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Product.Query.Handler
{
    public class GetAllProductsHandler : IRequestHandler<Request.GetAllProductsRequest, ResponseViewModel<IEnumerable<Domain.Models.Product>>>
    {
        private readonly IProductRepository repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResponseViewModel<IEnumerable<Domain.Models.Product>>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            SortBy sortBy = EnumExtensions.StringToEnum<SortBy>(request.SortBy);
            OrderByDirection orderByDirection = EnumExtensions.StringToEnum<OrderByDirection>(request.SortBy);

            var result = this.repository.GetAll(request.PageNumber, request.PageSize, sortBy, orderByDirection);

            return new ResponseViewModel<IEnumerable<Domain.Models.Product>> { Payload = result };
        }
    }
}