using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Domain.Interfaces.UnitOfWork;
using Global.Email.Infraestructure.Context;
using Global.Email.Infraestructure.Repositories;
using System.Threading.Tasks;

namespace Global.Email.Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Domain.Entities.Email> _emailrepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<Domain.Entities.Email> EmailRepository => _emailrepository ?? new BaseRepository<Domain.Entities.Email>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}