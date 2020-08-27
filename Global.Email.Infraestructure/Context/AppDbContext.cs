﻿using Microsoft.EntityFrameworkCore;

namespace Global.Email.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Email> Email { get; set; }
    }
}