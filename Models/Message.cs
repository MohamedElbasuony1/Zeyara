using System;

namespace Models
{
    public class Message : Entity
    {
        public DateTime Date { get; set; }
        public string Msg { get; set; }
        public bool? Read { get; set; }
        public bool? Delievered { get; set; }
        public bool? Deleted { get; set; }
        public int UserFrom_Id { get; set; }
        public int UserTo_Id { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
    }
}
