using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data;
using PycApi.Data.Model;
using System.Collections.Generic;


namespace PycApi.Mock
{

    [ApiController]
    [Route("nhb/v1/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private Product Product;
        private IHibernateRepository<Product> @object;


        public ProductController(IHibernateRepository<Product> repository, IMapper mapper)
        {
            this.@object = repository;
        }


        public ProductController(IHibernateRepository<Product> @object)
        {
            this.@object = @object;
        }
        [NonAction]
        [HttpGet]
        public List<Product> Get()
        {
            var product = @object.GetAll();
            return product;
        }
        [NonAction]
        [HttpGet("{id}")]
        public Product GetItem(int id)
        {
            var item = @object.GetById(id);

            if (item == null)
                return null;

            return item;
        }
    }
}
