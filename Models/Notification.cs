using System;

namespace Models
{
    public class Notification : Entity
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool? Read { get; set; }
        public int Tans_Id { get; set; }
        public Transaction Transaction { get; set; }
        public int UserFrom_Id { get; set; }
        public int UserTo_Id { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
    }
}
