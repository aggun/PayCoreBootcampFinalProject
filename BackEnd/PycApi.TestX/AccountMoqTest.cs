using Moq;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Mock;
using System.Collections.Generic;
using Xunit;

namespace PycApi.TestX
{
    public class MoqTestAccount
    {
        private readonly Mock<IHibernateRepository<Account>> _mockRepo;
        private readonly AccountController _controller;


        public MoqTestAccount()
        {
            _mockRepo = new Mock<IHibernateRepository<Account>>();
            _controller = new AccountController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Account>() { new Account { Name = "Daniel" }, new Account { Name = "Thomas" } });
        }


        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get();
            Assert.IsType<List<Account>>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex_Detail()
        {
            var result = _controller.GetItem(0);           
            Assert.Equal("Daniel", result.Name);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {
            var result = _controller.Get();
            var viewResult = Assert.IsType<List<Account>>(result);
            Assert.Equal(2, viewResult.Count);
        }

    }
}
