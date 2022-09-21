using AutoMapper;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<T> hibernateRepository;


        public BaseService(ISession session, IMapper mapper) : base()
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<T>(session);
        }

        public virtual BaseResponse<IEnumerable<T>> GetAll()
        {
            var tempEntity = hibernateRepository.Entities.ToList();
            var result = mapper.Map<IEnumerable<T>, IEnumerable<T>>(tempEntity);
            return new BaseResponse<IEnumerable<T>>(result);
        }

        public virtual BaseResponse<T> GetById(int id)
        {
            var tempEntity = hibernateRepository.GetById(id);
            var result = mapper.Map<T, T>(tempEntity);
            return new BaseResponse<T>(result);
        }

        public virtual BaseResponse<T> GetByStringId(string id)
        {
            var tempEntity = hibernateRepository.GetByStringId(id);
            var result = mapper.Map<T, T>(tempEntity);
            return new BaseResponse<T>(result);
        }

        public virtual BaseResponse<T> Insert(T insertResource)
        {
            try
            {
                var tempEntity = mapper.Map<T, T>(insertResource);              

                hibernateRepository.BeginTransaction();
                hibernateRepository.Save(tempEntity);
                hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();
                return new BaseResponse<T>(mapper.Map<T, T>(tempEntity));
            }
            catch (Exception ex)
            {
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<T>(ex.Message);
            }
        }

        public virtual BaseResponse<T> Remove(int id)
        {
            try
            {
                var tempEntity = hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<T>("Record Not Found");
                }

                hibernateRepository.BeginTransaction();
                hibernateRepository.Delete(id);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();

                return new BaseResponse<T>(mapper.Map<T, T>(tempEntity));
            }
            catch (Exception ex)
            {
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<T>(ex.Message);
            }
        }

        public virtual BaseResponse<T> Update( T updateResource)
        {
            try
            {
                hibernateRepository.BeginTransaction();
                hibernateRepository.Update(updateResource);
                hibernateRepository.Commit();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<T>(updateResource);
            }
            catch (Exception ex)
            {
                hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<T>(ex.Message);
            }
        }




    }
}
