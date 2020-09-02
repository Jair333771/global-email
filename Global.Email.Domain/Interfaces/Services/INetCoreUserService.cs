using Global.Email.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface INetCoreUserService<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task Delete(int id);
        Task<(bool, NetCoreUser)> GetByUser(T entity);
    }
}
