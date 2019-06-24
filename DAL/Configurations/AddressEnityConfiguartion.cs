using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class AddressEnityConfiguartion : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> AddressConfig)
        {
            AddressConfig.ToTable("Addresses");
            AddressConfig.HasKey(a => a.Id);
            AddressConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Addseq");
            AddressConfig.Property(a => a.City).IsRequired();
            AddressConfig.Property(a => a.Region).IsRequired();
            AddressConfig.Property(a => a.street).IsRequired();
            AddressConfig.Property(a => a.AddressType).IsRequired();

            AddressConfig
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.Usr_Id)
                .IsRequired();
        }
    }
}
