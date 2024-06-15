using HospitalSystem.Objects;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class AdminDoctorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctorData();
            }
        }

        private void LoadDoctorData()
        {
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");

            if (File.Exists(doctorFilePath))
            {
                string[] lines = File.ReadAllLines(doctorFilePath);
                foreach (string line in lines)
                {
                    string[] doctorData = line.Split(';');

                    if (doctorData.Length >= 9)
                    {
                        Doctor doctor = new Doctor
                        {
                            Name = doctorData[0],
                            LastName1 = doctorData[1],
                            LastName2 = doctorData[2],
                            NIC = doctorData[3],
                            CivilStatus = doctorData[4],
                            BirthDate = doctorData[5],
                            Phone = doctorData[6],
                            Email = doctorData[7],
                            Specialty = doctorData[8]
                        };

                        Table table = new Table { CssClass = "table table-bordered mb-4" };

                        AddTableRow(table, "Name", doctor.Name);
                        AddTableRow(table, "Last Name 1", doctor.LastName1);
                        AddTableRow(table, "Last Name 2", doctor.LastName2);
                        AddTableRow(table, "NIC", doctor.NIC);
                        AddTableRow(table, "Civil Status", doctor.CivilStatus);
                        AddTableRow(table, "Birth Date", doctor.BirthDate);
                        AddTableRow(table, "Phone", doctor.Phone);
                        AddTableRow(table, "Email", doctor.Email);
                        AddTableRow(table, "Specialty", doctor.Specialty);

                        phDoctorTable.Controls.Add(table);
                    }
                }
            }
            else
            {
                // Display error message using Bootstrap alert
                pnlError.Visible = true;
                lblErrorMessage.Text = "Doctor database not found. Please contact administrator.";
            }
        }

        private void AddTableRow(Table table, string header, string value)
        {
            TableRow row = new TableRow();
            TableCell cellHeader = new TableCell { Text = header, CssClass = "fw-bold" };
            TableCell cellValue = new TableCell { Text = value };

            row.Cells.Add(cellHeader);
            row.Cells.Add(cellValue);
            table.Rows.Add(row);
        }
    }
}
