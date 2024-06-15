using System;
using System.Web.UI;

namespace HospitalSystem
{
    public partial class PatientDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoToMedicalRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientMedicalRecord.aspx");
        }
    }
}
