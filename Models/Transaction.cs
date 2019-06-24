using System;
using System.Collections.Generic;

namespace Models
{
    public class Transaction : Entity
    {
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string QR_Code { get; set; }
        public bool? Accepted { get; set; }
        public bool? Completed { get; set; }
        public int Doctor_Id { get; set; }
        public User Doctor { get; set; }
        public int Patient_Id { get; set; }
        public User Patient { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
