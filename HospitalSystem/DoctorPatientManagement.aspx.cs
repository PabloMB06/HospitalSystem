using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorPatientManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiseases();
                LoadMedicines();
            }
        }

        private void LoadDiseases()
        {
            string diseasesFilePath = Server.MapPath("~/DB/disease.txt");
            if (File.Exists(diseasesFilePath))
            {
                List<string> diseases = new List<string>();
                using (StreamReader sr = new StreamReader(diseasesFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        diseases.Add(line);
                    }
                }

                ddlDisease.Items.Clear();
                ddlDisease.Items.Add(new ListItem("Select a disease", ""));
                foreach (string disease in diseases)
                {
                    ddlDisease.Items.Add(new ListItem(disease, disease));
                }
            }
        }

        private void LoadMedicines()
        {
            string medicinesFilePath = Server.MapPath("~/DB/medicine.txt");
            if (File.Exists(medicinesFilePath))
            {
                List<string> medicines = new List<string>();
                using (StreamReader sr = new StreamReader(medicinesFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        medicines.Add(line);
                    }
                }

                ddlMedicine.Items.Clear();
                ddlMedicine.Items.Add(new ListItem("Select a medicine", ""));
                foreach (string medicine in medicines)
                {
                    ddlMedicine.Items.Add(new ListItem(medicine, medicine));
                }
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
            string disease = ddlDisease.SelectedValue;
            string medicine = ddlMedicine.SelectedValue;

            // Prepare patient data line
            string patientData = $"{name};{lastName1};{lastName2};{nic};{civilStatus};{birthDate};{phone};{email};{residency};{disease};{medicine}";

            // Append patient data to file
            File.AppendAllText(patientFilePath, Environment.NewLine + patientData);

            // Clear form fields after adding patient
            ClearFormFields();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showSuccessAlert('Patient added successfully!');", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePatientDashboard.aspx");
        }

        private void ClearFormFields()
        {
            // Clear all textboxes and dropdowns
            txtName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtLastName2.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtCivilStatus.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtResidency.Text = string.Empty;
            ddlDisease.SelectedIndex = 0;
            ddlMedicine.SelectedIndex = 0;
        }
    }
}
