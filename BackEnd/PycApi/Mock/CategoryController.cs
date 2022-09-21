using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data;
using PycApi.Data.Model;
using System.Collections.Generic;


namespace PycApi.Mock
{

    [ApiController]
    [Route("nhb/v1/api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private Category Category;
        private IHibernateRepository<Category> @object;


        public CategoryController(IHibernateRepository<Category> repository, IMapper mapper)
        {
            this.@object = repository;
        }


        public CategoryController(IHibernateRepository<Category> @object)
        {
            this.@object = @object;
        }
        [NonAction]
        [HttpGet]
        public List<Category> Get()
        {
            var category = @object.GetAll();
            return category;
        }
        [NonAction]
        [HttpGet("{id}")]
        public Category GetItem(int id)
        {
            var item = @object.GetById(id);

            if (item == null)
                return null;

            return item;
        }
    }
}
