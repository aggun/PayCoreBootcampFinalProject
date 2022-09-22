using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data.Model;
using PycApi.Dto.Dto;
using PycApi.Service;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PycApi.Controller
{
    [Route("api/nhb/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.mapper = mapper;
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = productService.GetAll();
            var productsDtos = mapper.Map<List<ProductDto>>(products.Response.ToList());
            return Ok(productsDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = productService.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productService.Remove(id);
            return NoContent();
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] ProductDto dto)
        {
            var accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            Product product = new();
            product.Brand = dto.Brand;
            product.ProductName = dto.ProductName;
            product.Color = dto.Color;
            product.Price = dto.Price;
            product.Descripton = dto.Descripton;
            product.CategoryId = dto.CategoryId;
            product.AccountId = accountId.ToString();
            product.isOfferable = false;
            product.isSold = false;
            var response = productService.Insert(product);
            return Ok(response);

        }
    }
}
