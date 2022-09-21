using Moq;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Mock;
using System.Collections.Generic;
using Xunit;

namespace PycApi.TestX
{
    public class CategoryMoqTest
    {
        private readonly Mock<IHibernateRepository<Category>> _mockRepo;
        private readonly CategoryController _controller;


        public CategoryMoqTest()
        {
            _mockRepo = new Mock<IHibernateRepository<Category>>();
            _controller = new CategoryController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Category>() { new Category { CategoryName = "Telephone" }, new Category { CategoryName = "Lamp" } });
        }


        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get();
            Assert.IsType<List<Category>>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex_Detail()
        {
            var result = _controller.GetItem(1);
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {
            var result = _controller.Get();
            var viewResult = Assert.IsType<List<Category>>(result);
            Assert.Equal(2, viewResult.Count);
        }

    }
}
