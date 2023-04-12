using MediatR;
using products_catalogue.Application.Category.Command.Request;
using products_catalogue.Application.Category.Query.Request;
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
        public async Task<IHttpActionResult> Get([FromUri] int PageNumber, [FromUri] int PageSize, [FromUri] string SortOrder)
        {
            var response = await this.mediator.Send(new GetAllCategoriesRequest { PageNumber = PageNumber, PageSize = PageSize, SortOrder = SortOrder });
            return Ok(response);
        }

        // POST api/categories
        public async Task<IHttpActionResult> Post([FromBody] AddCategoryRequest request)
        {
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
            var response = await this.mediator.Send(new RemoveCategoryRequest { Id = Guid.Parse(id) });
            return Ok(response);
        }
    }
}