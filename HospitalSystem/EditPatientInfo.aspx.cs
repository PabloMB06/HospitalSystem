using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class EditPatientInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string patientId = Request.QueryString["patientId"];
                LoadPatientInfo(patientId);
                LoadDiseases();
                LoadMedicines();
            }
        }

        private void LoadPatientInfo(string patientId)
        {
            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            if (File.Exists(patientFilePath))
            {
                string[] lines = File.ReadAllLines(patientFilePath);
                foreach (string line in lines)
                {
                    string[] patientData = line.Split(';');
                    if (patientData.Length > 10 && patientData[3] == patientId) // Verificar que la línea tiene al menos 11 elementos
                    {
                        txtName.Text = patientData[0];
                        txtLastName1.Text = patientData[1];
                        txtLastName2.Text = patientData[2];
                        txtNIC.Text = patientData[3];
                        txtCivilStatus.Text = patientData[4];
                        txtBirthDate.Text = patientData[5];
                        txtPhone.Text = patientData[6];
                        txtEmail.Text = patientData[7];
                        txtResidency.Text = patientData[8];
                        ddlDisease.SelectedValue = patientData[9];
                        ddlMedicine.SelectedValue = patientData[10];
                        break;
                    }
                }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string patientId = txtNIC.Text;
            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            if (File.Exists(patientFilePath))
            {
                string[] lines = File.ReadAllLines(patientFilePath);
                using (StreamWriter writer = new StreamWriter(patientFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] patientData = line.Split(';');
                        if (patientData.Length > 10 && patientData[3] == patientId) // Verificar que la línea tiene al menos 11 elementos
                        {
                            string updatedLine = $"{txtName.Text};{txtLastName1.Text};{txtLastName2.Text};{txtNIC.Text};{txtCivilStatus.Text};{txtBirthDate.Text};{txtPhone.Text};{txtEmail.Text};{txtResidency.Text};{ddlDisease.SelectedValue};{ddlMedicine.SelectedValue}";
                            writer.WriteLine(updatedLine);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                lblMessage.Text = "Patient info updated successfully.";
                lblMessage.Visible = true;
                Response.Redirect("FileList.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileList.aspx");
        }
    }
}
