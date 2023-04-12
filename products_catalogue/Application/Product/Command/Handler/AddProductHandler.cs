using AutoMapper;
using MediatR;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Product.Command.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, ResponseViewModel<Domain.Models.Product>>
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public AddProductHandler(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseViewModel<Domain.Models.Product>> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var mappedProduct = mapper.Map<Domain.Models.Product>(request);
            var response = await this.repository.Add(mappedProduct);
            return new ResponseViewModel<Domain.Models.Product>
            {
                Payload = response
            };
        }
    }
}