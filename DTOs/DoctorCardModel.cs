using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DoctorCardModel
    {
        public string Degree { get; set; }
        public string Bio { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; }
        public string Spc_Name { get; set; }
        public ICollection<CertificationModel> Certificates { get; set; }
        public ICollection<PhoneModel> Phones { get; set; }
        public ICollection<AddressModel> Addresses { get; set; }
        public UserProfileModel User { get; set; }
        public ICollection<ReviewsModel> Reviews { get; set; }
    }
}
