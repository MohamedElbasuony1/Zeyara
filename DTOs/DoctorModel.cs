using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
   public class DoctorModel
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
        public bool? Deleted { get; set; }
        public int Role_Id { get; set; }
        public string ESSN { get; set; }
        public string Degree { get; set; }
        public string Bio { get; set; }
        public string OfficialCard { get; set; }
        public int Experience { get; set; }
        public bool Verified { get; set; }
        public int Salary { get; set; }
        public bool Status { get; set; }
        public Card Card { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public int Specializations { get; set; }
    }
}
