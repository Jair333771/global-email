using Global.Email.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Entities.Email> EmailRepository { get; }
        void Dispose();
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
