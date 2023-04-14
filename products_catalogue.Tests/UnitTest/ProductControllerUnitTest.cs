using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using products_catalogue.Application.Product.Command.Request;
using products_catalogue.Application.Product.Query.Request;
using products_catalogue.Controllers;
using products_catalogue.Domain.Models;
using products_catalogue.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace products_catalogue.Tests.UnitTest
{
    [TestClass]
    public class ProductControllerUnitTest
    {
        private ProductsController controller;
        private Mock<IMediator> mediatorMock;

        [TestInitialize]
        public void Setup()
        {
            this.mediatorMock = new Mock<IMediator>();
            this.controller = new ProductsController(this.mediatorMock.Object);
        }

        [TestMethod]
        public async Task Get_ReturnsBadRequest_WhenFilterNotValid()
        {
            // Arrange
            int pageNumber = 0;
            int pageSize = 10;
            string sortBy = "Name";
            string sortOrder = "Asc";

            // Act
            IHttpActionResult result = await this.controller.Get(pageNumber, pageSize, sortBy, sortOrder);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            BadRequestErrorMessageResult badRequestResult = (BadRequestErrorMessageResult)result;
            Assert.AreEqual("Filter not valid", badRequestResult.Message);
        }

        [TestMethod]
        public async Task Get_WithValidParameters_ReturnsOk()
        {
            // Arrange
            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsRequest>(), default))
                .ReturnsAsync(new ResponseViewModel<IEnumerable<Product>>());

            // Act
            var result = await this.controller.Get(1, 10, "Name", "Asc");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ResponseViewModel<IEnumerable<Product>>>));
        }

        [TestMethod]
        public async Task GetById_WithValidId_ReturnsOk()
        {
            // Arrange
            mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdRequest>(), default))
                .ReturnsAsync(new ResponseViewModel<Product>());

            // Act
            var result = await controller.Get(Guid.NewGuid().ToString());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ResponseViewModel<Product>>));
        }

        [TestMethod]
        public async Task Put_WithValidRequest_ReturnsOk()
        {
            // Arrange
            mediatorMock.Setup(m => m.Send(It.IsAny<UpdateProductRequest>(), default))
                .ReturnsAsync(new ResponseViewModel<Product>());

            var id = Guid.NewGuid().ToString();
            var request = new UpdateProductRequest
            {
                Name = "Updated product",
                Description = "Updated description",
                CategoryId = "1",
                Image = "Updated image"
            };

            // Act
            var result = await controller.Put(id, request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ResponseViewModel<Product>>));
        }

        [TestMethod]
        public async Task Delete_WithValidId_ReturnsOk()
        {
            // Arrange
            mediatorMock.Setup(m => m.Send(It.IsAny<RemoveProductRequest>(), default))
                .ReturnsAsync(new ResponseViewModel<Guid>());

            // Act
            var result = await controller.Delete(Guid.NewGuid().ToString());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ResponseViewModel<Guid>>));
        }

        [TestMethod]
        public async Task Get_WithInvalidParameters_ReturnsBadRequest()
        {
            // Act
            var result = await controller.Get(-1, -1, "InvalidSortBy", "InvalidSortOrder");

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public async Task GetById_WithInvalidId_ReturnsBadRequest()
        {
            // Act
            var result = await controller.Get("-1");

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public async Task Post_WithInvalidRequest_ReturnsInvalidModelStateResult()
        {
            // Arrange
            controller.ModelState.AddModelError("error", "test error");

            var request = new AddProductRequest();

            // Act
            var result = await controller.Post(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public async Task Put_WithInvalidId_ReturnsBadRequest()
        {
            // Act
            var result = await controller.Put("-1", new UpdateProductRequest());

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public async Task Put_WithInvalidRequest_ReturnsInvalidModelStateResult()
        {
            // Arrange
            controller.ModelState.AddModelError("error", "test error");

            // Act
            var result = await controller.Put(Guid.NewGuid().ToString(), new UpdateProductRequest());

            // Assert
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public async Task Delete_WithInvalidId_ReturnsBadRequest()
        {
            // Act
            var result = await controller.Delete("-1");

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
