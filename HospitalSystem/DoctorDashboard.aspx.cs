using System;
using System.Web.UI;

namespace HospitalSystem
{
    public partial class DoctorDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoToPatientManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagePatientDashboard.aspx");
        }

        protected void btnGoToMedicineInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorMedicineInventory.aspx");
        }

        protected void btnGoToDiseaseRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorDiseaseRecord.aspx");
        }
    }
}
