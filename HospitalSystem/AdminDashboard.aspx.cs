using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminPatientManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPatientManagement.aspx");
        }

        protected void btnAdminDoctorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDoctorManagement.aspx");
        }

        protected void btnAdminMedicineInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMedicineInventory.aspx");
        }

        protected void btnAdminDiseaseRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDiseaseRecord.aspx");
        }
    }
}
