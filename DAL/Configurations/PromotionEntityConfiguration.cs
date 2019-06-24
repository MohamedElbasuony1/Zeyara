using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class PromotionEntityConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> PromotionConfig)
        {
            PromotionConfig.ToTable("Promotions");
            PromotionConfig.HasKey(a => a.Id);
            PromotionConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Promoseq");
            PromotionConfig.Property(a => a.Percentage).IsRequired();
            PromotionConfig.Property(a => a.ExpireDate).IsRequired();
        }
    }
}
