using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HospitalSystem
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = string.Empty;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim(); // Assuming you have a way to verify passwords

            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");

            if (File.Exists(patientFilePath) && File.Exists(doctorFilePath))
            {
                // Check if the user is a patient
                var patientLines = File.ReadAllLines(patientFilePath);
                var patientUser = patientLines
                    .Select(line => line.Split(';'))
                    .FirstOrDefault(fields => fields.Length >= 8 && fields[7].Equals(email, StringComparison.OrdinalIgnoreCase));

                if (patientUser != null && password == "patient") // Replace with actual patient password verification logic
                {
                    Session["Username"] = email;
                    Response.Redirect("PatientDashboard.aspx");
                    return;
                }

                // Check if the user is a doctor
                var doctorLines = File.ReadAllLines(doctorFilePath);
                var doctorUser = doctorLines
                    .Select(line => line.Split(';'))
                    .FirstOrDefault(fields => fields.Length >= 8 && fields[7].Equals(email, StringComparison.OrdinalIgnoreCase));

                if (doctorUser != null && password == "doctor") // Replace with actual doctor password verification logic
                {
                    Session["Username"] = email;
                    Response.Redirect("DoctorDashboard.aspx");
                    return;
                }

                // If neither patient nor doctor credentials match
                lblError.Text = "Invalid email or password.";
            }
            else
            {
                lblError.Text = "User database not found.";
            }
        }
    }
}
