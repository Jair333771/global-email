using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        int Update(T entity);
        Task Delete(int id);
    }
}
