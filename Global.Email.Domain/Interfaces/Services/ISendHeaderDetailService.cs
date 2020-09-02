using Global.Email.Application.Interface;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface ISendHeaderDetailService<T> where T : class
    {
        IGlobalResponse GetAll();
        Task<IGlobalResponse> GetById(int id);
        Task<IGlobalResponse> Add(T entity);
        Task<IGlobalResponse> Update(T entity);
        Task<IGlobalResponse> Delete(int id);
    }
}
