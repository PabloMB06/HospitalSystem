using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class FileList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatientList();
            }
        }

        private void LoadPatientList()
        {
            try
            {
                string patientFilePath = Server.MapPath("~/DB/patient.txt");

                if (File.Exists(patientFilePath))
                {
                    string[] lines = File.ReadAllLines(patientFilePath);
                    foreach (string line in lines)
                    {
                        string[] patientData = line.Split(';');
                        if (patientData.Length >= 9)
                        {
                            string patientName = $"{patientData[0]} {patientData[1]} {patientData[2]}";
                            TableRow row = new TableRow();

                            // Patient name cell with a hyperlink
                            TableCell nameCell = new TableCell();
                            HyperLink patientLink = new HyperLink
                            {
                                Text = patientName,
                                NavigateUrl = $"DoctorPatientList.aspx?patientId={patientData[3]}" // Redirects to DoctorPatientList.aspx with patient ID
                            };
                            nameCell.Controls.Add(patientLink);
                            row.Cells.Add(nameCell);

                            // Edit button cell
                            TableCell editCell = new TableCell();
                            Button editButton = new Button
                            {
                                Text = "Edit",
                                CssClass = "btn btn-warning",
                                PostBackUrl = $"EditPatientInfo.aspx?patientId={patientData[3]}" // Redirects to EditPatientInfo.aspx with patient ID
                            };
                            editCell.Controls.Add(editButton);
                            row.Cells.Add(editCell);

                            // Delete all info button cell
                            TableCell deleteAllCell = new TableCell();
                            Button deleteAllButton = new Button
                            {
                                Text = "Delete",
                                CssClass = "btn btn-danger",
                                OnClientClick = $"showDeleteModal('{patientData[3]}'); return false;"
                            };
                            deleteAllCell.Controls.Add(deleteAllButton);
                            row.Cells.Add(deleteAllCell);

                            tblPatientList.Rows.Add(row);
                        }
                        else
                        {
                            ShowErrorMessage($"Invalid patient data: {line}");
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Patient data file is missing.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while loading patient list: {ex.Message}");
            }
        }


        private void EditButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string patientId = e.CommandArgument.ToString();
                // Redirect to edit page with patient ID
                Response.Redirect($"EditPatient.aspx?patientId={patientId}");
            }
        }


        private void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string patientId = e.CommandArgument.ToString();
                // Implement delete functionality here, e.g., removing the patient from the file
                DeletePatient(patientId);
                // Reload the patient list to reflect changes
                LoadPatientList();
            }
        }

        private void DeletePatient(string patientId)
        {
            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            if (File.Exists(patientFilePath))
            {
                var lines = File.ReadAllLines(patientFilePath);
                var newLines = new List<string>();

                foreach (var line in lines)
                {
                    var patientData = line.Split(';');
                    if (patientData.Length >= 4 && patientData[3].Trim() != patientId.Trim()) // Comparacion exacta del ID del paciente
                    {
                        newLines.Add(line);
                    }
                }

                File.WriteAllLines(patientFilePath, newLines);
            }
        }


        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            string patientId = hfPatientIdToDelete.Value;
            if (!string.IsNullOrEmpty(patientId))
            {
                DeletePatient(patientId);
                DeleteAdditionalInfo(patientId);
                LoadPatientList();
            }
        }

        private void DeleteAdditionalInfo(string patientId)
        {
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
            string diseaseFilePath = Server.MapPath("~/DB/disease.txt");
            string medicineFilePath = Server.MapPath("~/DB/medicine.txt");

            DeleteFromFile(patientId, doctorFilePath);
            DeleteFromFile(patientId, diseaseFilePath);
            DeleteFromFile(patientId, medicineFilePath);
        }

        private void DeleteFromFile(string patientId, string filePath)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var line in lines)
                    {
                        string[] fields = line.Split(';');
                        if (fields.Length > 3 && fields[3] != patientId) // Assuming NIC is at index 3
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            // Implement your error message display logic here, e.g., using a Label or Literal control.
            lblErrorMessage.Text = message;
        }
    }
}