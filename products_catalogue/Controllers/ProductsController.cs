using MediatR;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Application.Product.Query.Request;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace products_catalogue.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/products
        public async Task<IHttpActionResult> Get([FromUri] int PageNumber, [FromUri] int PageSize, [FromUri] string SortOrder)
        {
            var response = await this.mediator.Send(new GetAllProductsRequest { PageNumber = PageNumber, PageSize = PageSize, SortOrder = SortOrder });
            return Ok(response);
        }

        // GET api/products/5
        public async Task<IHttpActionResult> Get(string id)
        {
            var response = await this.mediator.Send(new GetProductByIdRequest { Id = Guid.Parse(id) });
            return Ok(response);
        }

        // POST api/products
        public async Task<IHttpActionResult> Post([FromBody] AddProductRequest request)
        {
            var response = await this.mediator.Send(new AddProductRequest
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Image = request.Image,
            });
            return Ok(response);
        }

        // PUT api/products/5
        public async Task<IHttpActionResult> Put([FromUri] string id, [FromBody] UpdateProductRequest request)
        {
            var response = await this.mediator.Send(new UpdateProductRequest
            {
                Id = Guid.Parse(id),
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Image = request.Image,
            });
            return Ok(response);
        }

        // DELETE api/products/5
        public async Task<IHttpActionResult> Delete([FromUri] string id)
        {
            var response = await this.mediator.Send(new RemoveCategoryRequest { Id = Guid.Parse(id) });
            return Ok(response);
        }
    }
}
