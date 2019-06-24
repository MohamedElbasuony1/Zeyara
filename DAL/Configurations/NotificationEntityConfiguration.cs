using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> NotificationConfig)
        {
            NotificationConfig.ToTable("Notifications");
            NotificationConfig.HasKey(a => a.Id);
            NotificationConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Notiseq");
            NotificationConfig.Property(a => a.Date).IsRequired();
            NotificationConfig.Property(a => a.Message).IsRequired();
            NotificationConfig.Property(a => a.Read).IsRequired(false);
            NotificationConfig.Property(a => a.Read).HasDefaultValue(false);

            NotificationConfig
                .HasOne(a => a.UserFrom)
                .WithMany(a => a.NotificationsFrom)
                .HasForeignKey(a => a.UserFrom_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            NotificationConfig
                .HasOne(a => a.UserTo)
                .WithMany(a => a.NotificationsTo)
                .HasForeignKey(a => a.UserTo_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);


            NotificationConfig
                .HasOne(a => a.Transaction)
                .WithMany(a => a.Notifications)
                .HasForeignKey(a => a.Tans_Id)
                .IsRequired();

        }
    }
}
