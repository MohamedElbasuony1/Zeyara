using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class UserPromotionEntityConfiguration : IEntityTypeConfiguration<UserPromotion>
    {
        public void Configure(EntityTypeBuilder<UserPromotion> UserPromotionConfig)
        {
            UserPromotionConfig.ToTable("UserPromotions");
            UserPromotionConfig.HasKey(a => new { a.Prom_Id, a.User_Id });

            UserPromotionConfig
                .HasOne(a => a.Promotion)
                .WithMany(u => u.UserPromotions)
                .HasForeignKey(a => a.Prom_Id)
                .IsRequired();

            UserPromotionConfig
              .HasOne(a => a.User)
              .WithMany(u => u.UserPromotions)
              .HasForeignKey(a => a.User_Id)
              .IsRequired();
        }
    }
}
