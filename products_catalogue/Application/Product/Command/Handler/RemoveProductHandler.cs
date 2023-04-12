using MediatR;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Product.Command.Handler
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, ResponseViewModel<Guid>>
    {
        private readonly IProductRepository repository;

        public RemoveProductHandler(IProductRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<ResponseViewModel<Guid>> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            this.repository.Remove(request.Id);
            return Task.FromResult(new ResponseViewModel<Guid>
            {
                Payload = request.Id,
            });
        }
    }
}