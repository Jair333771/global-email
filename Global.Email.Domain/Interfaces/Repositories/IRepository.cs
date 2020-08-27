using Global.Email.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task AddRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        Task Delete(int id);
    }
}
