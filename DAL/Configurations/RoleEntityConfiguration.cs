using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> RoleConfig)
        {
            RoleConfig.ToTable("Roles");
            RoleConfig.HasKey(a => a.Id);
            RoleConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Roleseq");
            RoleConfig.Property(a => a.Role_Name).IsRequired();
        }
    }
}
