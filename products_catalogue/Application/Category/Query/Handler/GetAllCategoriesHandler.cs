using MediatR;
using products_catalogue.Application.Category.Query.Request;
using products_catalogue.Domain.Enums;
using products_catalogue.Domain.Models;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using products_catalogue.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Category.Query.Handler
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, ResponseViewModel<IEnumerable<Domain.Models.Category>>>
    {
        private readonly ICategoryRepository repository;

        public GetAllCategoriesHandler(ICategoryRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ResponseViewModel<IEnumerable<Domain.Models.Category>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            SortBy sortBy = EnumExtensions.StringToEnum<SortBy>(request.SortBy);
            OrderByDirection orderByDirection = EnumExtensions.StringToEnum<OrderByDirection>(request.SortOrder);
            var result = this.repository.GetAll(request.PageNumber, request.PageSize, sortBy, orderByDirection);

            return new ResponseViewModel<IEnumerable<Domain.Models.Category>>
            {
                Metadata = new Metadata
                {
                    Action = "GetAll_categories",
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = $"Success",
                    CurrentPageNumber = request.PageNumber,
                    CurrentPageSize = request.PageSize,
                },
                Payload = result
            };
        }
    }
}