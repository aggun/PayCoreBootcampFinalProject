using Moq;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Mock;
using System.Collections.Generic;
using Xunit;

namespace PycApi.TestX
{
    public class OfferMoqTest
    {
        private readonly Mock<IHibernateRepository<Offer>> _mockRepo;
        private readonly OfferController _controller;


        public OfferMoqTest()
        {
            _mockRepo = new Mock<IHibernateRepository<Offer>>();
            _controller = new OfferController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Offer>() { new Offer { BidderAccount = "Maria" }, new Offer { BidderAccount = "Daniel" } });
        }


        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get();
            Assert.IsType<List<Offer>>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex_Detail()
        {
            var result = _controller.GetItem(1);
            Assert.IsType<Offer>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {
            var result = _controller.Get();
            var viewResult = Assert.IsType<List<Offer>>(result);
            Assert.Equal(2, viewResult.Count);
        }
    }
}
