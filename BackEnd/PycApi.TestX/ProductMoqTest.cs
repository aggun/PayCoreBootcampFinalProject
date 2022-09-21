using Moq;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Mock;
using System.Collections.Generic;
using Xunit;

namespace PycApi.TestX
{
    public class ProductMoqTest
    {
        private readonly Mock<IHibernateRepository<Product>> _mockRepo;
        private readonly ProductController _controller;


        public ProductMoqTest()
        {
            _mockRepo = new Mock<IHibernateRepository<Product>>();
            _controller = new ProductController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Product>() { new Product { ProductName = "Telephone" }, new Product { ProductName = "Lamp" } });
        }


        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get();
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex_Detail()
        {
            var result = _controller.GetItem(1);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {
            var result = _controller.Get();
            var viewResult = Assert.IsType<List<Product>>(result);
            Assert.Equal(2, viewResult.Count);
        }

    }
}
