using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data;
using PycApi.Data.Model;
using System.Collections.Generic;


namespace PycApi.Mock
{

    [ApiController]
    [Route("nhb/v1/api/[controller]")]
    public class OfferController : ControllerBase
    {
        private Offer Offer;
        private IHibernateRepository<Offer> @object;


        public OfferController(IHibernateRepository<Offer> repository, IMapper mapper)
        {
            this.@object = repository;
        }


        public OfferController(IHibernateRepository<Offer> @object)
        {
            this.@object = @object;
        }
        [NonAction]
        [HttpGet]
        public List<Offer> Get()
        {
            var offer = @object.GetAll();
            return offer;
        }
        [NonAction]
        [HttpGet("{id}")]
        public Offer GetItem(int id)
        {
            var item = @object.GetById(id);

            if (item == null)
                return null;

            return item;
        }
    }
}
