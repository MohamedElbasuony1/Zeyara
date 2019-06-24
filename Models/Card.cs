using System.Collections.Generic;

namespace Models
{
   public class Card
    {
        public string Number { get; set; }
        public string Card_Type { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
