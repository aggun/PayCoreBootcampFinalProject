using AutoMapper;
using NHibernate;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Dto;

namespace PycApi.Service
{

    public class ProductService: BaseService<Product>, IProductService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Product> hibernateRepository;

        public ProductService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Product>(session);
        }




    }
}

