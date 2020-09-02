using Global.Email.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Email.Infraestructure.DataConfiguration
{
    class SendHeaderConfiguration : IEntityTypeConfiguration<SendHeader>
    {
        public void Configure(EntityTypeBuilder<SendHeader> builder)
        {
            builder.ToTable("send_header");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ApplicationId)
                .IsRequired()
                .HasColumnName("application_id");

            builder.Property(e => e.SubApplicationId)
                .IsRequired()
               .HasColumnName("sub_application_id");

            builder.Property(e => e.ByName)
               .HasColumnName("by_name")
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.ByEmail)
               .HasColumnName("by_email")
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.DescSubject)
               .HasColumnName("desc_subject")
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

            builder.Property(e => e.SendDate)
              .HasColumnName("send_date")
              .HasColumnType("datetime");

            builder.Property(e => e.SendUser)
              .HasColumnName("send_user")
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(e => e.ForMail)
               .HasColumnName("for_mail")
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.ForMailCc)
              .HasColumnName("for_mail_cc")
              .HasMaxLength(100)
              .IsUnicode(false);

            builder.Property(e => e.ForMailBcc)
              .HasColumnName("for_mail_bcc")
              .HasMaxLength(100)
              .IsUnicode(false);

            builder.Property(e => e.ProcessId)
              .IsRequired()
              .HasColumnName("process_id");

            builder.Property(e => e.SubProcessId)
              .IsRequired()
              .HasColumnName("sub_process_id");

            builder.Property(e => e.TemplateId)
              .IsRequired()
              .HasColumnName("template_id");

            builder.Property(e => e.SnComplete)
              .IsRequired()
              .HasColumnName("sn_complete");

            builder.Property(e => e.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("datetime");

            builder.Property(e => e.SnInProcess)
                .HasColumnName("sn_in_process");

            builder.Property(e => e.SchedulingDate)
                .HasColumnName("scheduling_date");

            builder.Property(e => e.SnMassive)
                .IsRequired()
                .HasColumnName("sn_massive");
        }
    }
}
