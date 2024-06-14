using HospitalSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class Login : System.Web.UI.Page
    {
        Patient patient = new Patient();
        Doctor doctor = new Doctor();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (username == "admin" && password == "admin")
            {
                Response.Redirect("AdminDashboard.aspx");
            }
        }
    }
}