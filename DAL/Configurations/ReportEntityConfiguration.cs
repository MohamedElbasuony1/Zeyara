using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> ReportConfig)
        {
            ReportConfig.ToTable("Reports");
            ReportConfig.HasKey(a => a.Id);
            ReportConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Reposeq");
            ReportConfig.Property(a => a.Desc).IsRequired();
            ReportConfig.Property(a => a.Date).IsRequired();
            ReportConfig.Property(a => a.Zyara_Date).IsRequired();


            ReportConfig
                .HasOne(a => a.UserFrom)
                .WithMany(u => u.ReportsFrom)
                .HasForeignKey(a => a.UserFrom_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);


            ReportConfig
                .HasOne(a => a.UserTo)
                .WithMany(u => u.ReportsTo)
                .HasForeignKey(a => a.UserTo_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
