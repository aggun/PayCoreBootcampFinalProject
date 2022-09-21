using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data;
using PycApi.Data.Model;
using System.Collections.Generic;


namespace PycApi.Mock
{

    [ApiController]
    [Route("nhb/v1/api/[controller]")]
    public class AccountController : ControllerBase
    {
        private Account Account;
        private IHibernateRepository<Account> @object;


        public AccountController(IHibernateRepository<Account> repository, IMapper mapper)
        {
            this.@object = repository;
        }


        public AccountController(IHibernateRepository<Account> @object)
        {
            this.@object = @object;
        }
        [NonAction]
        [HttpGet]
        public List<Account> Get()
        {
            var account = @object.GetAll();
            return account;
        }
        [NonAction]
        [HttpGet("{id}")]
        public Account GetItem(int id)
        {
            var item = @object.GetById(id);

            if (item == null)
                return null;

            return item;
        }
    }
}
