using Global.Email.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Global.Email.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Email> Email { get; set; }
        public DbSet<SendHeader> SendHeader { get; set; }
        public DbSet<SendHeaderDetail> SendHeaderDetail { get; set; }
        public DbSet<NetCoreUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}