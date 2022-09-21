using AutoMapper;
using NHibernate;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Dto;

namespace PycApi.Service
{

    public class OrderService : BaseService<Order>, IOrderService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Category> hibernateRepository;

        public OrderService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Category>(session);
        }




    }
}

