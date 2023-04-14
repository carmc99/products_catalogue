using MediatR;
using products_catalogue.App_Start;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Application.Product.Query.Request;
using products_catalogue.Domain.Enums;
using products_catalogue.Domain.Models;
using products_catalogue.Domain.ViewModels;
using products_catalogue.Utils;
using Serilog;
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
        private readonly ILogger logger;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = ApplicationLogging.Logger;
        }

        // GET api/products
        [ResponseType(typeof(ResponseViewModel<IEnumerable<Product>>))]
        public async Task<IHttpActionResult> Get([FromUri] int pageNumber, [FromUri] int pageSize, [FromUri] string sortBy, [FromUri] string sortOrder)
        {
            if (pageNumber <= 0 || pageSize <= 0
                || !EnumExtensions.IsValid<SortBy>(sortBy)
                || !EnumExtensions.IsValid<OrderByDirection>(sortOrder))
            {
                logger.Warning("ProductController|GetAll: Filtro no valido");
                return BadRequest("Filter not valid");
            }
            var response = await this.mediator.Send(new GetAllProductsRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder
            });
            logger.Information("CategoriesController|GetAll: Operacion completada con exito");
            return Ok(response);
        }

        // GET api/products/5
        [ResponseType(typeof(ResponseViewModel<Product>))]
        public async Task<IHttpActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                logger.Warning("ProductController|Get: Se recibio un ID de producto no valido");
                return BadRequest("Valid product Id is required.");
            }
            var response = await this.mediator.Send(new GetProductByIdRequest { Id = Guid.Parse(id) });
            logger.Information("CategoriesController|GetAll: Operacion completada con exito");
            return Ok(response);
        }

        // POST api/products
        [ResponseType(typeof(ResponseViewModel<Product>))]
        public async Task<IHttpActionResult> Post([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid || !GuidParser.IsValidGuid(request.CategoryId))
            {
                logger.Warning("ProductController|Post: Modelo no valido");
                return BadRequest(ModelState);
            }

            var response = await this.mediator.Send(new AddProductRequest
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Image = request.Image,
            });
            logger.Information("CategoriesController|GetAll: Operacion completada con exito");
            return Ok(response);
        }

        // PUT api/products/5
        [ResponseType(typeof(ResponseViewModel<Product>))]
        public async Task<IHttpActionResult> Put([FromUri] string id, [FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                logger.Warning("ProductController|Put: Modelo no valido");
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                logger.Warning("ProductController|Put: Se recibio un ID de producto no valido");
                return BadRequest("Valid product Id is required.");
            }

            var response = await this.mediator.Send(new UpdateProductRequest
            {
                Id = Guid.Parse(id),
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Image = request.Image,
            });
            logger.Information("CategoriesController|GetAll: Operacion completada con exito");
            return Ok(response);
        }

        // DELETE api/products/5
        [ResponseType(typeof(ResponseViewModel<Guid>))]
        public async Task<IHttpActionResult> Delete([FromUri] string id)
        {
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                logger.Warning("ProductController|Delete: Se recibio un ID de producto no valido");
                return BadRequest("Valid product Id is required.");
            }
            var response = await this.mediator.Send(new RemoveProductRequest { Id = Guid.Parse(id) });
            logger.Information("CategoriesController|GetAll: Operacion completada con exito");
            return Ok(response);
        }
    }
}
