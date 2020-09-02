using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface ISendHeaderDetailService<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task Delete(int id);
    }
}
