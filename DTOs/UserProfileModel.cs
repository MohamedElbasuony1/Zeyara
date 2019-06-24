using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Rate { get; set; }
        public string Image { get; set; }
        public decimal Widget { get; set; }
        public string Email { get; set; }
    }
}
