using PycApi.Base;
using System.Collections.Generic;

namespace PycApi.Service
{
    public interface IBaseService<T> where T : class
    {
        BaseResponse<T> GetById(int id);
        BaseResponse<IEnumerable<T>> GetAll();
        BaseResponse<T> Insert(T insertResource);
        BaseResponse<T> Update(T updateResource);
        BaseResponse<T> Remove(int id);
        BaseResponse<T> GetByStringId(string id);
    }
}
