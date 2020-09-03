using Global.Email.Domain.Entities;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface INetCoreUserService<T> : IBaseService<T> where T : class
    {
        Task<(bool, NetCoreUser)> GetByUser(T entity);
    }
}
