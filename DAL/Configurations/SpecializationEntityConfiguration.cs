using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class SpecializationEntityConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> SpecializationConfig)
        {
            SpecializationConfig.ToTable("Specializations");
            SpecializationConfig.HasKey(a => a.Id);
            SpecializationConfig.HasIndex(a => a.Spc_Name).IsUnique();
            SpecializationConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Specseq");
            SpecializationConfig.Property(a => a.Spc_Name).IsRequired();
        }
    }
}
