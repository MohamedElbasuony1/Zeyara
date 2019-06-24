using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class PhoneEntityConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> PhoneConfig)
        {
            PhoneConfig.ToTable("Phones");
            PhoneConfig.HasKey(a => new { a.Usr_Id, a.Number });
            PhoneConfig.Property(a => a.Number).HasMaxLength(14);
            PhoneConfig.Property(a => a.Number).IsFixedLength();
            PhoneConfig.Property(a => a.Number).IsRequired();

            PhoneConfig
                .HasOne(a => a.User)
                .WithMany(u => u.Phones)
                .HasForeignKey(a => a.Usr_Id)
                .IsRequired();
        }
    }
}
