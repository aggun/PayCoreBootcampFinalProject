using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Service;
using System.Linq;
using System.Security.Claims;

namespace PycApi.Controller
{
    [Route("api/nhb/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IOfferService offerService;
 
        public AccountController(IOfferService offerService)
        {
            this.offerService = offerService;
        }
        [HttpGet("MySendOffer")]
        public IActionResult MySendOffer ()
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var offers = offerService.GetAll();
            var myOffer= offers.Response.Where(x=>x.BidderAccount==accountId).ToList();
            return Ok(myOffer);
        }
        [HttpGet("MyReceiveOffer")]
        public IActionResult MyReceiveOffer()
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var offers = offerService.GetAll();
            var myOffer = offers.Response.Where(x => x.ProductOwner == accountId).ToList();
            return Ok(myOffer);
        }

        [HttpPost("ConfirmOffer")]
        public IActionResult ConfirmOffer(int id)
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var offers = offerService.GetAll();
            var myOffer = offers.Response.Where(x => x.ProductOwner == accountId).ToList();
            var confirm= myOffer.Where(x=>x.Id == id).FirstOrDefault();
            confirm.Approval = true;
            offerService.Update(confirm);
            return Ok();
        }
        [HttpPost("RefuseOffer")]
        public IActionResult RefuseOffer(int id)
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var offers = offerService.GetAll();
            var myOffer = offers.Response.Where(x => x.ProductOwner == accountId).ToList();
            var confirm = myOffer.Where(x => x.Id == id).FirstOrDefault();
            confirm.Approval = false;
            offerService.Update(confirm);
            return Ok();
        }



    }
}
