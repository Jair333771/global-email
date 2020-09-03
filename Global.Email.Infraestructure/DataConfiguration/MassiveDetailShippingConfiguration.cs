using Global.Email.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Global.Email.Infraestructure.DataConfiguration
{
    class MassiveDetailShippingConfiguration : IEntityTypeConfiguration<MassiveDetailShipping>
    {
        public void Configure(EntityTypeBuilder<MassiveDetailShipping> builder)
        {
            builder.ToTable("massive_detail_shipping");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Consecutive)
               .IsRequired()
               .HasColumnName("consecutive");

            builder.Property(e => e.ListNumber)
               .IsRequired()
               .HasColumnName("list_number");

            builder.Property(e => e.Email)
               .IsRequired()
               .HasMaxLength(250)
               .HasColumnName("email");

            builder.Property(e => e.ProcessId)
               .IsRequired()
               .HasColumnName("process_id");

            builder.Property(e => e.SubProcessId)
               .IsRequired()
               .HasColumnName("sub_process_id");

            builder.Property(e => e.TemplateId)
               .IsRequired()
               .HasColumnName("template_id");

            builder.Property(e => e.ListId)
               .IsRequired()
               .HasColumnName("list_id");

            builder.Property(e => e.CampaignId)
               .IsRequired()
               .HasColumnName("campaign_id");

            builder.Property(e => e.PvCeroId)
               .IsRequired()
               .HasColumnName("pv_cero_id");

            builder.Property(e => e.PersonId)
               .IsRequired()
               .HasColumnName("person_id");

            builder.Property(e => e.Column1)
               .HasMaxLength(60)
               .HasColumnName("column1");

            builder.Property(e => e.Column2)
               .HasMaxLength(60)
               .HasColumnName("column2");

            builder.Property(e => e.Column3)
               .HasMaxLength(60)
               .HasColumnName("column3");

            builder.Property(e => e.Column4)
               .HasMaxLength(60)
               .HasColumnName("column4");

            builder.Property(e => e.Column5)
               .HasMaxLength(60)
               .HasColumnName("column5");

            builder.Property(e => e.Column6)
               .HasMaxLength(60)
               .HasColumnName("column6");

            builder.Property(e => e.Column7)
               .HasMaxLength(60)
               .HasColumnName("column7");

            builder.Property(e => e.Column8)
               .HasMaxLength(60)
               .HasColumnName("column8");

            builder.Property(e => e.Column9)
               .HasMaxLength(60)
               .HasColumnName("column9");

            builder.Property(e => e.Column10)
               .HasMaxLength(60)
               .HasColumnName("column10");

            builder.Property(e => e.Column11)
               .HasMaxLength(60)
               .HasColumnName("column11");

            builder.Property(e => e.Column12)
               .HasMaxLength(60)
               .HasColumnName("column12");

            builder.Property(e => e.Column13)
               .HasMaxLength(60)
               .HasColumnName("column13");

            builder.Property(e => e.Column14)
               .HasMaxLength(60)
               .HasColumnName("column14");

            builder.Property(e => e.Column15)
               .HasMaxLength(60)
               .HasColumnName("column15");

            builder.Property(e => e.Column16)
               .HasMaxLength(60)
               .HasColumnName("column16");

            builder.Property(e => e.Column17)
               .HasMaxLength(60)
               .HasColumnName("column17");

            builder.Property(e => e.Column18)
               .HasMaxLength(60)
               .HasColumnName("column18");

            builder.Property(e => e.Column19)
               .HasMaxLength(60)
               .HasColumnName("column19");

            builder.Property(e => e.Column20)
               .HasMaxLength(60)
               .HasColumnName("column20");

            builder.Property(e => e.Status)
               .HasColumnName("status");

            builder.Property(e => e.StatusDate)
               .HasColumnName("status_date");

            builder.Property(e => e.SnComplete)
               .HasColumnName("sn_complete");

            builder.Property(e => e.MemberApiId)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("member_api_id");

            builder.Property(e => e.EmailApiId)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("email_api_id");

            builder.Property(e => e.DescError)
               .HasMaxLength(200)
               .HasColumnName("desc_error");

        }
    }
}
