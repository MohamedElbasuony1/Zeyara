using System;

namespace Models
{
    public class Comment:Entity
    {
        public string Desc { get; set; }
        public DateTime Date { get; set; }
        public float Rate { get; set; }
        public bool? Deleted { get; set; }
        public int UserFrom_Id { get; set; }
        public User UserFrom { get; set; }
        public int UserTo_Id { get; set; }
        public User UserTo { get; set; }
    }
}
