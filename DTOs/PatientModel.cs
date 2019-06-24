using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public decimal Widget { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<AddressModel> Addresses { get; set; }
        public ICollection<PhoneModel> Phones { get; set; }
        public ICollection<ReviewsModel> Reviews { get; set; }
    }
}
