using System.Collections.Generic;

namespace Models
{
    public class Specialization : Entity
    {
        public string Spc_Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
