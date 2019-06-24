using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressEnityConfiguartion());
            modelBuilder.ApplyConfiguration(new CardEnityConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OnlineUserEntityConfiguartion());
            modelBuilder.ApplyConfiguration(new PhoneEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReportEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SpecializationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionEnittyConfiguation());
            modelBuilder.ApplyConfiguration(new UserEntityConfigration());
            modelBuilder.ApplyConfiguration(new UserPromotionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenEntityConfiguration());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OnlineUser> OnlineUsers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserPromotion> UserPromotions { get; set; }
    }
}
