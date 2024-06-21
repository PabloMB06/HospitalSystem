using HospitalSystem.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorPatientManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            string patientFilePath = Server.MapPath("~/DB/patient.txt");

            // Collect data from form fields
            string name = txtName.Text.Trim();
            string lastName1 = txtLastName1.Text.Trim();
            string lastName2 = txtLastName2.Text.Trim();
            string nic = txtNIC.Text.Trim();
            string civilStatus = txtCivilStatus.Text.Trim();
            string birthDate = txtBirthDate.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string residency = txtResidency.Text.Trim();

            // Prepare patient data line
            string patientData = $"{name};{lastName1};{lastName2};{nic};{civilStatus};{birthDate};{phone};{email};{residency};";

            // Append patient data to file
            File.AppendAllText(patientFilePath, Environment.NewLine + patientData);

            // Clear form fields after adding patient
            ClearFormFields();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showSuccessAlert('Patient added successfully!');", true);
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
                        if (patientFields.Length >= 9 && patientFields[3] == patientId)
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
     

        
        //Cambio boton Back to patient list
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePatientDashboard");
        }

        private void ClearFormFields()
        {
            // Clear all textboxes
            txtName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtLastName2.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtCivilStatus.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtResidency.Text = string.Empty;
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
