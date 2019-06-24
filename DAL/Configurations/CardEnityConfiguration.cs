using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class CardEnityConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> CardConfig)
        {
            CardConfig.ToTable("Cards");
            CardConfig.HasKey(a => a.Number);
            CardConfig.Property(a => a.Card_Type).IsRequired(true);
        }
    }
}
