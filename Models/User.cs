using System;
using System.Collections.Generic;

namespace Models
{
    public class User : Entity
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Rate { get; set; }
        public string Image { get; set; }
        public int Widget { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
        public bool? Deleted { get; set; }
        public int Role_Id { get; set; }
        public Role Role { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
        public ICollection<Comment> CommentsTo { get; set; }
        public ICollection<Comment> CommentsFrom { get; set; }
        public ICollection<Message> MessagesTo { get; set; }
        public ICollection<Message> MessagesFrom { get; set; }
        public ICollection<OnlineUser> OnlineUsers { get; set; }
        public ICollection<Notification> NotificationsFrom { get; set; }
        public ICollection<Notification> NotificationsTo { get; set; }
        public ICollection<Transaction> TransactionsDoctor { get; set; }
        public ICollection<Transaction> TransactionsPatient { get; set; }
        public ICollection<Report> ReportsFrom { get; set; }
        public ICollection<Report> ReportsTo { get; set; }
        public ICollection<UserPromotion> UserPromotions { get; set; }
    }
}
