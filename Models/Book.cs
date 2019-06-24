using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Book
    {
        public int doctorId { get; set; }
        public int patientId { get; set; }
        public Location location { get; set; }
    }
}
