using AutoMapper;
using MediatR;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Domain.Models;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Product.Command.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ResponseViewModel<Domain.Models.Product>>
    {
        private readonly IProductRepository productrepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public UpdateProductHandler(IProductRepository productrepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.productrepository = productrepository ?? throw new ArgumentNullException(nameof(productrepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseViewModel<Domain.Models.Product>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var category = this.categoryRepository.GetById(Guid.Parse(request.CategoryId));
            if (category != null)
            {
                var mappedProduct = mapper.Map<Domain.Models.Product>(request);
                var response = await this.productrepository.Update(request.Id, mappedProduct);
                return new ResponseViewModel<Domain.Models.Product>
                {
                    Metadata = new Metadata
                    {
                        Action = "Update_product",
                        StatusCode = (int)HttpStatusCode.OK,
                        Message = $"Success"
                    },
                    Payload = response
                };
            }
            return new ResponseViewModel<Domain.Models.Product>
            {
                Metadata = new Metadata
                {
                    Action = "Update_product",
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = $"Category Id: {request.CategoryId} not found"
                }
            };

        }
    }
}