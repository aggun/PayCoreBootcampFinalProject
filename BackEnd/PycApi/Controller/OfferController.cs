using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data.Model;
using PycApi.Service;
using System.Security.Claims;

namespace PycApi.Controller
{
    [Route("api/nhb/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferController : ControllerBase
    {

        private readonly IOfferService offerService;
        private readonly IProductService productService;

        public OfferController(IOfferService offerService,  IProductService productService)
        {
            this.offerService = offerService;
            this.productService = productService;
        }
        [HttpPost]
        public IActionResult SendOffer(int id, double price)
        {
            bool isOfferable = productService.GetById(id).Response.isOfferable;
            if (isOfferable)
            {
                Offer offer = new Offer();
                offer.BidderAccount = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
                offer.ProductOwner = productService.GetById(id).Response.AccountId;
                offer.OfferPrice = price;
                offer.Approval = false;
                offer.ProductId = id;

                offerService.Insert(offer);
                return Ok(offer);
            }
            else
            {
                return BadRequest("Bu ürüne teklif verilemez.");
            }
        }
    }
}
