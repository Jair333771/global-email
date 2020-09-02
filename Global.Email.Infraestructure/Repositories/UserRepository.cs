using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Global.Email.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<NetCoreUser>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {           
        }

        public async Task<NetCoreUser> GetByUser(string name)
        {
            var entity = await _entities
                .FirstOrDefaultAsync(x => x.User == name);

            return entity;
        }
    }
}
