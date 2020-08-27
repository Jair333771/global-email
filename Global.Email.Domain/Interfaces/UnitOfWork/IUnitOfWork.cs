using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Global.Email.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}