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
    }
}
