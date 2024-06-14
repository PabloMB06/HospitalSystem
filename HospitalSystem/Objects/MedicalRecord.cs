using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Objects
{
    public class MedicalRecord
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Disease Disease { get; set; }
        public Medicine Medicine { get; set; }
    }
}