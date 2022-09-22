using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data.Model;
using PycApi.Service;
using System.Linq;
using System.Security.Claims;

namespace PycApi.Controller
{
    [Route("api/nhb/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IOfferService offerService;

        public OrderController(IOrderService orderService, IProductService productService, IOfferService offerService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.offerService = offerService;
        }


        [HttpGet]
        public IActionResult CreateOrder()
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            var orders = orderService.GetAll().Response.Where(x => x.AccountId == accountId).ToList();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder(int id)
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            Order order = new();
            var product = productService.GetById(id).Response;
            order.AccountId = accountId;
            order.ProductName = product.ProductName;
            order.Price = product.Price;
            orderService.Insert(order);
            product.isSold = false;
            product.isOfferable = false;
            productService.Update(product);

            return Ok(order);
        }
    }
}
