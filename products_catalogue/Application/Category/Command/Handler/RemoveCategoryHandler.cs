using MediatR;
using products_catalogue.Application.Category.Command.Request;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Category.Command.Handler
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryRequest, ResponseViewModel<Guid>>
    {
        private readonly ICategoryRepository repository;

        public RemoveCategoryHandler(ICategoryRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<ResponseViewModel<Guid>> Handle(RemoveCategoryRequest request, CancellationToken cancellationToken)
        {
            this.repository.Remove(request.Id);
            return Task.FromResult(new ResponseViewModel<Guid>
            {
                Payload = request.Id,
            });
        }
    }
}