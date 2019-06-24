using System;
using System.Collections.Generic;

namespace Models
{
   public class Doctor
    {
        public string ESSN { get; set; }
        public string Degree { get; set; }
        public string Bio { get; set; }
        public string OfficialCard { get; set; }
        public int Experience { get; set; }
        public bool Verified { get; set; }
        public int Salary { get; set; }
        public bool Status { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }
        public string Card_Id { get; set; }
        public Card Card { get; set; }
        public int Spec_Id { get; set; }
        public Specialization Specialization { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
    }
}
