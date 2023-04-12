using MediatR;
using products_catalogue.Application.Product.Query.Request;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/products
        public void Post([FromBody] string value)
        {
        }

        // PUT api/products/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
