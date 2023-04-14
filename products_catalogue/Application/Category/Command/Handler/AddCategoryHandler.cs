using AutoMapper;
using MediatR;
using products_catalogue.Application.Category.Command.Request;
using products_catalogue.Domain.Models;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace products_catalogue.Application.Category.Command.Handler
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, ResponseViewModel<Domain.Models.Category>>
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;

        public AddCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResponseViewModel<Domain.Models.Category>> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var mappedCategory = mapper.Map<Domain.Models.Category>(request);
            var response = await this.repository.Add(mappedCategory);
            return new ResponseViewModel<Domain.Models.Category>
            {
                Metadata = new Metadata
                {
                    Action = "Add_category",
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = $"Success"
                },
                Payload = response
            };
        }
    }
}