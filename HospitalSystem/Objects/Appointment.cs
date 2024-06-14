using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Objects
{
    public class Appointment
    {
        public DateTime Visit { get; set; } = DateTime.Now;

        public string VisitFormatted
        {
            get { return Visit.ToString("MM/dd/yyyy"); }
        }
    }
}