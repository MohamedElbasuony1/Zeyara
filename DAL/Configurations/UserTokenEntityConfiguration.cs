using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class UserTokenEntityConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> UserTokenConfig)
        {
            UserTokenConfig.ToTable("UserTokens");
            UserTokenConfig.HasKey(a => new { a.TokenNumber, a.Usr_Id });

            UserTokenConfig
                .HasOne(a => a.User)
                .WithMany(u => u.UserTokens)
                .HasForeignKey(a => a.Usr_Id)
                .IsRequired();
               
        }
    }
}
