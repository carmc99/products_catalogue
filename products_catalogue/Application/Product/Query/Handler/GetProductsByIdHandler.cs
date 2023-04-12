using MediatR;
using products_catalogue.Application.Product.Query.Request;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Product.Query.Handler
{
    public class GetProductsByIdHandler : IRequestHandler<Request.GetProductByIdRequest, ResponseViewModel<Domain.Models.Product>>
    {
        private readonly IProductRepository repository;

        public GetProductsByIdHandler(IProductRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<ResponseViewModel<Domain.Models.Product>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetById(request.Id);

            return Task.FromResult(new ResponseViewModel<Domain.Models.Product> { Payload = result });
        }
    }
}