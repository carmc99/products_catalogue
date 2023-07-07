using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace products_catalogue.Tests.IntegrationTest
{
    /// <summary>
    /// Descripción resumida de ProductServiceIntegrationTest
    /// </summary>
    [TestClass]
    public class ProductControllerIntTest
    {
        //private HttpConfiguration config;
        //private HttpServer server;
        //private HttpClient client;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    config = new HttpConfiguration();
        //    WebApiConfig.Register(config);
        //    server = new HttpServer(config);
        //    client = new HttpClient(server);

        //    // Set the BaseAddress property
        //    client.BaseAddress = new Uri("http://localhost/");
        //}

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    client.Dispose();
        //    server.Dispose();
        //}

        //[TestMethod]
        //public async Task TestGetAllProducts()
        //{
        //    // Act
        //    var response = await client.GetAsync("api/products?pageNumber=1&pageSize=10&sortBy=Name&sortOrder=Asc");

        //    // Assert
        //    Assert.IsNotNull(response);
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    var content = await response.Content.ReadAsAsync<ResponseViewModel<IEnumerable<Product>>>();
        //    Assert.IsNotNull(content);
        //}
    }
}
