using Global.Email.Domain.Entities;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<NetCoreUser>
    {
        Task<NetCoreUser> GetByUser(string user);
    }
}
