using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> MessageConfig)
        {
            MessageConfig.ToTable("Messages");
            MessageConfig.HasKey(a => a.Id);
            MessageConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Msgseq");
            MessageConfig.Property(a => a.Msg).IsRequired();
            MessageConfig.Property(a => a.Read).IsRequired(false);
            MessageConfig.Property(a => a.Read).HasDefaultValue(false);
            MessageConfig.Property(a => a.Delievered).IsRequired(false);
            MessageConfig.Property(a => a.Delievered).HasDefaultValue(false);
            MessageConfig.Property(a => a.Deleted).IsRequired(false);
            MessageConfig.Property(a => a.Deleted).HasDefaultValue(false);
            MessageConfig.Property(a => a.Date).IsRequired();

            MessageConfig
                .HasOne(a => a.UserFrom)
                .WithMany(a => a.MessagesFrom)
                .HasForeignKey(a => a.UserFrom_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            MessageConfig
                .HasOne(a => a.UserTo)
                .WithMany(a => a.MessagesTo)
                .HasForeignKey(a => a.UserTo_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
