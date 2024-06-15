using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Objects
{
    public class AppUser
    {
        public string Username { get; set; } // optional
        public string Password { get; set; } // optional
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string NIC { get; set; } // National Identification Card or ID Card
        public string CivilStatus { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; } // Phone Number
        public string Email { get; set; } // Email
    }

    public class Patient : AppUser
    {
        public string Residency { get; set; } // Province
    }

    public class Doctor : AppUser
    {
        public string Specialty { get; set; } // Dentist, Surgeon, Cardiologist, etc.
    }
}