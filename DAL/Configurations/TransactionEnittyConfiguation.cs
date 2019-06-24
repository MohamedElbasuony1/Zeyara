using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class TransactionEnittyConfiguation : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> TransactionConfig)
        {
            TransactionConfig.ToTable("Transactions");
            TransactionConfig.HasKey(a => a.Id);
            TransactionConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Transeq");
            TransactionConfig.Property(a => a.Date).IsRequired();
            TransactionConfig.Property(a => a.QR_Code).IsRequired(false);
            TransactionConfig.Property(a => a.Location).IsRequired();
            TransactionConfig.Property(a => a.Accepted).HasDefaultValue(null);
            TransactionConfig.Property(a => a.Completed).HasDefaultValue(null);

            TransactionConfig
                .HasOne(a => a.Patient)
                .WithMany(u => u.TransactionsPatient)
                .HasForeignKey(a => a.Patient_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            TransactionConfig
                .HasOne(a => a.Doctor)
                .WithMany(u => u.TransactionsDoctor)
                .HasForeignKey(a => a.Doctor_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
