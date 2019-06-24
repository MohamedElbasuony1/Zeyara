using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class CertificateEntityConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> CertificateConfig)
        {
            CertificateConfig.ToTable("Certificates");
            CertificateConfig.HasKey(a => a.Id);
            CertificateConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Certseq");
            CertificateConfig.Property(a => a.Certi_Img).IsRequired();
            CertificateConfig.Property(a => a.Certi_Title).IsRequired();
            CertificateConfig.Property(a => a.ESSN).HasMaxLength(14);
            CertificateConfig.Property(a => a.ESSN).IsFixedLength();

            CertificateConfig
                .HasOne(a => a.Doctor)
                .WithMany(u => u.Certificates)
                .HasForeignKey(a => a.ESSN)
                .IsRequired();

        }
    }
}
