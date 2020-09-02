using Global.Email.Application.Interface;
using Global.Email.Domain.Entities;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface INetCoreUserService<T> where T : class
    {
        IGlobalResponse GetAll();
        Task<IGlobalResponse> GetById(int id);
        Task<IGlobalResponse> Add(T entity);
        Task<IGlobalResponse> Update(T entity);
        Task<IGlobalResponse> Delete(int id);    
        Task<(bool, NetCoreUser)> GetByUser(T entity);
    }
}
