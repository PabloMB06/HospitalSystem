using HospitalSystem.Objects;
using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class PatientDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicalRecord();
            }
        }

        private void LoadMedicalRecord()
        {
            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
            string diseaseFilePath = Server.MapPath("~/DB/disease.txt");
            string medicineFilePath = Server.MapPath("~/DB/medicine.txt");

            string loggedInEmail = Session["Username"] as string;
            if (string.IsNullOrEmpty(loggedInEmail))
            {
                // Handle the case where the session has expired or the user is not logged in
                Response.Redirect("Login.aspx");
                return;
            }

            if (File.Exists(patientFilePath) && File.Exists(doctorFilePath) && File.Exists(diseaseFilePath) && File.Exists(medicineFilePath))
            {
                // Read patient data
                string[] patientLines = File.ReadAllLines(patientFilePath);
                Patient patient = null;

                foreach (var line in patientLines)
                {
                    string[] fields = line.Split(';');
                    if (fields.Length >= 9 && fields[7] == loggedInEmail)
                    {
                        patient = new Patient
                        {
                            Name = fields[0],
                            LastName1 = fields[1],
                            LastName2 = fields[2],
                            NIC = fields[3],
                            CivilStatus = fields[4],
                            BirthDate = fields[5],
                            Phone = fields[6],
                            Email = fields[7],
                            Residency = fields[8]
                        };
                        break;
                    }
                }

                if (patient == null)
                {
                    // Handle case where no matching patient is found
                    Response.Redirect("Login.aspx");
                    return;
                }

                // Read doctor data (assuming one doctor for simplicity)
                string[] doctorData = File.ReadAllText(doctorFilePath).Split(';');
                Doctor doctor = new Doctor
                {
                    Name = doctorData[0],
                    LastName1 = doctorData[1],
                    LastName2 = doctorData[2],
                    Specialty = doctorData[8],
                };

                // Get random disease and medicine
                string diseaseName = GetRandomEntryFromFile(diseaseFilePath);
                string medicineName = GetRandomEntryFromFile(medicineFilePath);

                Disease disease = new Disease
                {
                    Name = diseaseName
                };

                Medicine medicine = new Medicine
                {
                    Name = medicineName,
                    Prescription = DateTime.Now
                };

                MedicalRecord medicalRecord = new MedicalRecord
                {
                    Doctor = doctor,
                    Patient = patient,
                    Disease = disease,
                    Medicine = medicine
                };

                // Simulate appointments
                Appointment nextAppointment = new Appointment { Visit = DateTime.Now.AddDays(30) };

                // Create and populate table
                Table table = new Table { CssClass = "table table-bordered" };

                AddTableRow(table, "Patient Name", $"{medicalRecord.Patient.Name} {medicalRecord.Patient.LastName1}");
                AddTableRow(table, "NIC", medicalRecord.Patient.NIC);
                AddTableRow(table, "Email", medicalRecord.Patient.Email);
                AddTableRow(table, "Doctor", $"{medicalRecord.Doctor.Name} {medicalRecord.Doctor.LastName1} - {medicalRecord.Doctor.Specialty}");
                AddTableRow(table, "Disease", medicalRecord.Disease.Name);
                AddTableRow(table, "Medicine", medicalRecord.Medicine.Name);
                AddTableRow(table, "Upcoming Appointment", nextAppointment.VisitFormatted);

                phPatientTable.Controls.Add(table);
            }
        }

        private void AddTableRow(Table table, string header, string value)
        {
            TableRow row = new TableRow();
            TableCell cellHeader = new TableCell { Text = header, CssClass = "fw-bold" };
            TableCell cellValue = new TableCell { Text = value };

            row.Cells.Add(cellHeader);
            row.Cells.Add(cellValue);
            table.Rows.Add(row);
        }

        private string GetRandomEntryFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] entries = File.ReadAllText(filePath).Split(new[] { ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                Random random = new Random();
                return entries[random.Next(entries.Length)];
            }
            return "Unknown";
        }
    }
}
