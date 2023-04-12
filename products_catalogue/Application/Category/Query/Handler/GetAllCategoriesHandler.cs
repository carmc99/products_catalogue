using MediatR;
using products_catalogue.Application.Category.Query.Request;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
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
            var result = this.repository.GetAll(request.PageNumber, request.PageSize, request.SortOrder);

            return new ResponseViewModel<IEnumerable<Domain.Models.Category>> { Payload = result };
        }
    }
}