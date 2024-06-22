using HospitalSystem.Objects;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorPatientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si se proporcionó un ID de paciente válido en la URL
                if (!string.IsNullOrEmpty(Request.QueryString["patientId"]))
                {
                    string patientId = Request.QueryString["patientId"];
                    LoadPatientData(patientId);
                }
                else
                {
                    // Si no se proporciona un ID de paciente, redirige a DoctorPatientManagement.aspx
                    Response.Redirect("DoctorPatientManagement.aspx");
                }
            }
        }

        private void LoadPatientData(string patientId)
        {
            try
            {
                string patientFilePath = Server.MapPath("~/DB/patient.txt");
                string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
                string diseaseFilePath = Server.MapPath("~/DB/disease.txt");
                string medicineFilePath = Server.MapPath("~/DB/medicine.txt");

                if (File.Exists(patientFilePath) && File.Exists(doctorFilePath) && File.Exists(diseaseFilePath) && File.Exists(medicineFilePath))
                {
                    string[] patientData = File.ReadAllLines(patientFilePath);

                    foreach (string line in patientData)
                    {
                        string[] patientFields = line.Split(';');
                        if (patientFields.Length >= 11 && patientFields[3] == patientId)
                        {
                            Patient patient = new Patient
                            {
                                Name = patientFields[0],
                                LastName1 = patientFields[1],
                                LastName2 = patientFields[2],
                                NIC = patientFields[3],
                                CivilStatus = patientFields[4],
                                BirthDate = patientFields[5],
                                Phone = patientFields[6],
                                Email = patientFields[7],
                                Residency = patientFields[8]
                            };

                            Doctor doctor = new Doctor();
                            string[] doctorData = File.ReadAllLines(doctorFilePath);
                            if (doctorData.Length > 0)
                            {
                                string[] doctorFields = doctorData[0].Split(';');
                                if (doctorFields.Length >= 9)
                                {
                                    doctor.Name = doctorFields[0];
                                    doctor.LastName1 = doctorFields[1];
                                    doctor.LastName2 = doctorFields[2];
                                    doctor.Specialty = doctorFields[8];
                                }
                            }

                            // Obtiene la enfermedad y medicina del archivo de pacientes
                            string diseaseName = patientFields[9];
                            string medicineName = patientFields[10];

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

                            CreateTable(medicalRecord);
                            return;
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Some data files are missing.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while loading patient data: {ex.Message}");
            }

            // Si no se encuentra el paciente con el ID proporcionado, muestra un mensaje de error
            ShowErrorMessage("Patient not found.");
        }

        private void CreateTable(MedicalRecord medicalRecord)
        {
            Table table = new Table { CssClass = "table table-bordered mb-4" };

            AddTableRow(table, "Name", medicalRecord.Patient.Name);
            AddTableRow(table, "Last Name 1", medicalRecord.Patient.LastName1);
            AddTableRow(table, "Last Name 2", medicalRecord.Patient.LastName2);
            AddTableRow(table, "NIC", medicalRecord.Patient.NIC);
            AddTableRow(table, "Civil Status", medicalRecord.Patient.CivilStatus);
            AddTableRow(table, "Birth Date", medicalRecord.Patient.BirthDate);
            AddTableRow(table, "Phone", medicalRecord.Patient.Phone);
            AddTableRow(table, "Email", medicalRecord.Patient.Email);
            AddTableRow(table, "Residency", medicalRecord.Patient.Residency);
            AddTableRow(table, "Disease", medicalRecord.Disease.Name);
            AddTableRow(table, "Medicine", $"{medicalRecord.Medicine.Name} (Prescribed on: {medicalRecord.Medicine.PrescriptionFormatted})");
            AddTableRow(table, "Doctor", $"{medicalRecord.Doctor.Name} {medicalRecord.Doctor.LastName1} {medicalRecord.Doctor.LastName2} - {medicalRecord.Doctor.Specialty}");

            phPatientTable.Controls.Add(table);
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

        private void ShowErrorMessage(string message)
        {
            phPatientTable.Controls.Add(new LiteralControl($"<p class='text-danger'>{message}</p>"));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileList.aspx");
        }
    }
}
