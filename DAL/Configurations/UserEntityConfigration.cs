using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class UserEntityConfigration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> UserConfig)
        {
            UserConfig.ToTable("Users");
            UserConfig.HasKey(a => a.Id);
            UserConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Userseq");
            UserConfig.Property(a => a.Fname).IsRequired().HasMaxLength(15);
            UserConfig.Property(a => a.Lname).IsRequired().HasMaxLength(15);
            UserConfig.Property(a => a.Age).IsRequired();
            UserConfig.Property(a => a.Gender).IsRequired();
            UserConfig.Property(a => a.Rate).HasDefaultValue(0.0);
            UserConfig.Property(a => a.Image).IsRequired(false);
            UserConfig.Property(a => a.Widget).HasDefaultValue(0);
            UserConfig.Property(a => a.Email).IsRequired();
            UserConfig.HasIndex(a => a.Email).IsUnique();
            UserConfig.Property(a => a.Password).IsRequired();
            UserConfig.Ignore(a => a.CPassword);
            UserConfig.Property(a => a.Deleted).IsRequired(false);
            UserConfig.Property(a => a.Deleted).HasDefaultValue(false);

            UserConfig
                .HasOne(a => a.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(a => a.Role_Id)
                .IsRequired();
                
        }
    }
}
