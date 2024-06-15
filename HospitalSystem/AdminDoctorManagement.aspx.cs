using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;

namespace HospitalSystem
{
    public partial class AdminDoctorManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initial setup if needed
            }
        }

        protected void btnAddDoctor_Click(object sender, EventArgs e)
        {
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");

            // Collect data from form fields
            string firstName = txtFirstName.Text.Trim();
            string lastName1 = txtLastName1.Text.Trim();
            string lastName2 = txtLastName2.Text.Trim();
            string nic = txtNIC.Text.Trim();
            string civilStatus = txtCivilStatus.Text.Trim();
            string birthDate = txtBirthDate.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string specialization = txtSpecialization.Text.Trim();

            // Prepare doctor data line
            string doctorData = $"{firstName};{lastName1};{lastName2};{nic};{civilStatus};{birthDate};{phone};{email};{specialization};";

            // Append doctor data to file
            File.AppendAllText(doctorFilePath, Environment.NewLine + doctorData);

            // Clear form fields after adding doctor
            ClearFormFields();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showSuccessAlert('Doctor added successfully!');", true);
        }

        protected void btnEditDoctor_Click(object sender, EventArgs e)
        {
            string emailToEdit = txtEmail.Text.Trim(); // Edit based on email address

            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
            List<string> lines = new List<string>(File.ReadAllLines(doctorFilePath));

            bool doctorFound = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] doctorData = lines[i].Split(';');

                if (doctorData.Length > 7 && doctorData[7] == emailToEdit)
                {
                    // Update doctor data with form values
                    doctorData[0] = txtFirstName.Text.Trim();
                    doctorData[1] = txtLastName1.Text.Trim();
                    doctorData[2] = txtLastName2.Text.Trim();
                    doctorData[3] = txtNIC.Text.Trim();
                    doctorData[4] = txtCivilStatus.Text.Trim();
                    doctorData[5] = txtBirthDate.Text.Trim();
                    doctorData[6] = txtPhone.Text.Trim();
                    doctorData[7] = txtEmail.Text.Trim(); // Update email if necessary
                    doctorData[8] = txtSpecialization.Text.Trim();

                    // Join doctor data back into a single line
                    lines[i] = string.Join(";", doctorData);

                    doctorFound = true;
                    break; // Exit loop once doctor is found and updated
                }
            }

            if (doctorFound)
            {
                // Rewrite the entire file with updated doctor data
                File.WriteAllLines(doctorFilePath, lines);

                // Optionally, clear the form fields after editing
                ClearFormFields();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showSuccessAlert('Doctor updated successfully!');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showErrorAlert('Doctor not found or could not be updated.');", true);
            }
        }

        protected void btnDeleteDoctor_Click(object sender, EventArgs e)
        {
            string emailToDelete = txtEmail.Text.Trim();

            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
            List<string> lines = new List<string>(File.ReadAllLines(doctorFilePath));

            bool doctorFound = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] doctorData = lines[i].Split(';');

                if (doctorData.Length > 7 && doctorData[7] == emailToDelete)
                {
                    lines.RemoveAt(i);
                    doctorFound = true;
                    break; // Exit loop once doctor is found and removed
                }
            }

            if (doctorFound)
            {
                // Rewrite the entire file with the doctor data removed
                File.WriteAllLines(doctorFilePath, lines);

                // Optionally, clear the form fields after deleting
                ClearFormFields();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showSuccessAlert('Doctor deleted successfully!');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showErrorAlert('Doctor not found or could not be deleted.');", true);
            }
        }

        private void ClearFormFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtLastName2.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtCivilStatus.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
        }
    }
}
