using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> DoctorConfig)
        {
            DoctorConfig.ToTable("Doctors");
            DoctorConfig.HasKey(a => a.ESSN);
            DoctorConfig.Property(a => a.ESSN).HasMaxLength(14);
            DoctorConfig.Property(a => a.ESSN).IsFixedLength();
            DoctorConfig.Property(a => a.Degree).IsRequired();
            DoctorConfig.Property(a => a.Bio).IsRequired(false);
            DoctorConfig.Property(a => a.Experience).IsRequired();
            DoctorConfig.Property(a => a.Verified).IsRequired();
            DoctorConfig.Property(a => a.Verified).HasDefaultValue(false);
            DoctorConfig.Property(a => a.Salary).IsRequired();
            DoctorConfig.Property(a => a.Status).IsRequired();
            DoctorConfig.Property(a => a.Status).HasDefaultValue(false);
            DoctorConfig.Property(a => a.OfficialCard).IsRequired();

            DoctorConfig
                .HasOne(a => a.Card)
                .WithMany(u=>u.Doctors)
                .HasForeignKey(a=>a.Card_Id)
                .IsRequired();

            DoctorConfig
                .HasOne(a => a.Specialization)
                .WithMany(u => u.Doctors)
                .HasForeignKey(a => a.Spec_Id)
                .IsRequired();

            DoctorConfig
                .HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<Doctor>("User_Id");

        }
    }
}
