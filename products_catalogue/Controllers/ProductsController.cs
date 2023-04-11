using System.Collections.Generic;
using System.Web.Http;

namespace products_catalogue.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
