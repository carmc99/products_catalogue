using MediatR;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Application.Product.Query.Request;
using products_catalogue.Domain.Enums;
using products_catalogue.Domain.Models;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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
        [ResponseType(typeof(ResponseViewModel<IEnumerable<Product>>))]
        public async Task<IHttpActionResult> Get([FromUri] int PageNumber, [FromUri] int PageSize, [FromUri] string SortBy, [FromUri] string SortOrder)
        {
            if (PageNumber <= 0 || PageSize <= 0
                || !EnumExtensions.IsValid<SortBy>(SortBy)
                || !EnumExtensions.IsValid<OrderByDirection>(SortOrder))
            {
                return BadRequest("Filter not valid");
            }
            var response = await this.mediator.Send(new GetAllProductsRequest
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                SortBy = SortBy,
                SortOrder = SortOrder
            });
            return Ok(response);
        }

        // GET api/products/5
        [ResponseType(typeof(ResponseViewModel<Product>))]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                return BadRequest("Valid product Id is required.");
            }
            var response = await this.mediator.Send(new GetProductByIdRequest { Id = Guid.Parse(id) });
            return Ok(response);
        }

        // POST api/products
        [ResponseType(typeof(ResponseViewModel<Product>))]
        public async Task<IHttpActionResult> Post([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid || !GuidParser.IsValidGuid(request.CategoryId))
            {
                return BadRequest(ModelState);
            }

            var response = await this.mediator.Send(new AddProductRequest
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Image = request.Image,
            });
            return Ok(response);
        }

        // PUT api/products/5
        [ResponseType(typeof(ResponseViewModel<Product>))]
        public async Task<IHttpActionResult> Put([FromUri] string id, [FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                return BadRequest("Valid product Id is required.");
            }

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
        [ResponseType(typeof(ResponseViewModel<Guid>))]
        public async Task<IHttpActionResult> Delete([FromUri] string id)
        {
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                return BadRequest("Valid product Id is required.");
            }
            var response = await this.mediator.Send(new RemoveProductRequest { Id = Guid.Parse(id) });
            return Ok(response);
        }
    }
}
