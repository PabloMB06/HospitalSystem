using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Objects
{
    public class Medicine
    {
        public string Name { get; set; }
        public string Pharmacy { get; set; }
        public string Amount { get; set; }
        public DateTime Prescription { get; set; } = DateTime.Now;

        public string PrescriptionFormatted
        {
            get { return Prescription.ToString("MM/dd/yyyy"); }
        }
    }
}