using MediatR;
using products_catalogue.Application.Category.Command.Request;
using products_catalogue.Application.Category.Query.Request;
using products_catalogue.Domain.Enums;
using products_catalogue.Utils;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace products_catalogue.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/categories
        public async Task<IHttpActionResult> Get([FromUri] int pageNumber, [FromUri] int pageSize, [FromUri] string sortBy, [FromUri] string sortOrder)
        {
            if (pageNumber <= 0 || pageSize <= 0
                || !EnumExtensions.IsValid<SortBy>(sortBy)
                || !EnumExtensions.IsValid<OrderByDirection>(sortOrder))
            {
                return BadRequest("Filter not valid");
            }
            var response = await this.mediator.Send(new GetAllCategoriesRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder
            });
            return Ok(response);
        }

        // POST api/categories
        public async Task<IHttpActionResult> Post([FromBody] AddCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await this.mediator.Send(new AddCategoryRequest
            {
                Name = request.Name,
                Description = request.Description,
            });
            return Ok(response);
        }

        // DELETE api/categories/5
        public async Task<IHttpActionResult> Delete([FromUri] string id)
        {
            if (string.IsNullOrEmpty(id) || !GuidParser.IsValidGuid(id))
            {
                return BadRequest("Valid category Id is required.");
            }
            var response = await this.mediator.Send(new RemoveCategoryRequest { Id = Guid.Parse(id) });
            return Ok(response);
        }
    }
}