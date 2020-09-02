using Global.Email.Domain.Entities;
using Global.Email.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Global.Email.Infraestructure.DataConfiguration
{
    class NetCoreConfiguration : IEntityTypeConfiguration<NetCoreUser>
    {
        public void Configure(EntityTypeBuilder<NetCoreUser> builder)
        {
            builder.ToTable("netcore_users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.User)
               .HasColumnName("user")
               .IsRequired()
               .HasMaxLength(250)
               .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasColumnName("user_name")
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Role)
              .HasColumnName("role")
              .HasMaxLength(50)
              .IsRequired()
              .HasConversion(
                   x => x.ToString(),
                   x => (RoleType)Enum.Parse(typeof(RoleType), x)
               );
        }
    }
}
