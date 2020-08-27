using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global.Email.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _entities;

        public BaseRepository(AppDbContext context)
        {
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            var list = _entities.ToList();

            foreach (var item in list)
            {
                yield return item;
            }
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _entities.FindAsync(id);
            return entity;
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRange(List<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _entities.Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _entities.AttachRange(entities);
            _entities.UpdateRange(entities);
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Attach(entity);
            _entities.Remove(entity);
        }
    }
}