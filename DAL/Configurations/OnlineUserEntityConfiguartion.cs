using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class OnlineUserEntityConfiguartion : IEntityTypeConfiguration<OnlineUser>
    {
        public void Configure(EntityTypeBuilder<OnlineUser> OnlineUserConfig)
        {
            OnlineUserConfig.ToTable("OnlineUsers");
            OnlineUserConfig.HasKey(a => new { a.ConnectionId, a.Usr_Id });

            OnlineUserConfig
                .HasOne(a => a.User)
                .WithMany(u => u.OnlineUsers)
                .HasForeignKey(a => a.Usr_Id)
                .IsRequired();
        }
    }
}
