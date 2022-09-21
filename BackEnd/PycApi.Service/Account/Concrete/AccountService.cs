using AutoMapper;
using FluentNHibernate.Data;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Dto;
using Serilog;
using System;

namespace PycApi.Service
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Account> hibernateRepository;

        public AccountService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;
            hibernateRepository = new HibernateRepository<Account>(session);
        }
    }
}
