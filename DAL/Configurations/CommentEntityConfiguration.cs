using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> CommentConfig)
        {
            CommentConfig.ToTable("Comments");
            CommentConfig.HasKey(a => a.Id);
            CommentConfig.Property(a => a.Id).ForSqlServerUseSequenceHiLo("Commseq");
            CommentConfig.Property(a => a.Date).IsRequired();
            CommentConfig.Property(a => a.Desc).IsRequired(false);
            CommentConfig.Property(a => a.Rate).IsRequired();
            CommentConfig.Property(a => a.Deleted).IsRequired(false);
            CommentConfig.Property(a => a.Deleted).HasDefaultValue(false);

            CommentConfig
                .HasOne(a => a.UserFrom)
                .WithMany(a => a.CommentsFrom)
                .HasForeignKey(a => a.UserFrom_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            CommentConfig
                .HasOne(a => a.UserTo)
                .WithMany(a => a.CommentsTo)
                .HasForeignKey(a => a.UserTo_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
