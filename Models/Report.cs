using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Report:Entity
    {
        public string Desc  { get; set; }
        public DateTime Date { get; set; }
        public DateTime Zyara_Date { get; set; }
        public int UserFrom_Id { get; set; }
        public int UserTo_Id { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
    }
}
