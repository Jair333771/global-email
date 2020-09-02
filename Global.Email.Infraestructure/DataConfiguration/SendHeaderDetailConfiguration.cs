using Global.Email.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Global.Email.Infraestructure.DataConfiguration
{
    class SendHeaderDetailConfiguration : IEntityTypeConfiguration<SendHeaderDetail>
    {
        public void Configure(EntityTypeBuilder<SendHeaderDetail> builder)
        {
            builder.ToTable("send_header_detail");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.SendHeaderId)
                .HasColumnName("send_header_id")
                .IsRequired();

            builder.Property(e => e.ApiId)
               .HasColumnName("api_id")
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.FromEmail)
               .HasColumnName("from_email")
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.ConfirmDate)
               .HasColumnName("confirm_date")
               .HasColumnType("datetime");
            ;

            builder.Property(e => e.ReturnDate)
               .HasColumnName("return_date")
               .HasColumnType("datetime");

            builder.Property(e => e.StatusCode)
              .HasColumnName("status_code");

            builder.Property(e => e.DescState)
              .HasColumnName("desc_state")
              .HasMaxLength(50);

            builder.Property(e => e.DetailState)
               .HasColumnName("details_state")
               .HasMaxLength(100);

            builder.Property(e => e.DestinationTypeId)
              .HasColumnName("destination_type_id");

            builder.Property(e => e.PersonId)
              .HasColumnName("person_id")
              .HasColumnType("NUMERIC(7, 0)")
              .IsRequired();

            builder.Property(e => e.PvCeroId)
              .HasColumnName("pv_cero_id")
              .IsRequired();

            builder.Property(e => e.CreationDate)
              .HasColumnType("datetime")
              .HasColumnName("creation_date");

            builder.Property(e => e.DetailId)
              .HasColumnName("detail_id")
              .IsRequired();

            builder.Property(e => e.SnInProceso)
              .IsRequired()
              .HasColumnName("sn_in_process");

            builder.Property(e => e.PqCode)
                .HasColumnName("pq_code");

            builder.Property(e => e.AvanceCode)
                .HasColumnName("avance_code");

            builder.Property(e => e.NumberOperations)
                .HasColumnName("number_operations");
        }
    }
}
