using System;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorDiseaseRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiseaseData();
            }
        }

        protected void btnAddDisease_Click(object sender, EventArgs e)
        {
            string newDisease = txtNewDisease.Text.Trim();
            if (!string.IsNullOrEmpty(newDisease))
            {
                string diseaseFilePath = Server.MapPath("~/DB/disease.txt");
                AppendDiseaseToFile(diseaseFilePath, newDisease);
                LoadDiseaseData(); // Refresh the data displayed on the page
                txtNewDisease.Text = ""; // Clear the text box
            }
        }

        protected void btnDeleteDisease_Click(object sender, EventArgs e)
        {
            string diseaseToDelete = txtNewDisease.Text.Trim();
            if (!string.IsNullOrEmpty(diseaseToDelete))
            {
                string diseaseFilePath = Server.MapPath("~/DB/disease.txt");
                DeleteDiseaseFromFile(diseaseFilePath, diseaseToDelete);
                LoadDiseaseData(); // Refresh the data displayed on the page
                txtNewDisease.Text = ""; // Clear the text box
            }
        }

        private void LoadDiseaseData()
        {
            string diseaseFilePath = Server.MapPath("~/DB/disease.txt");

            try
            {
                // Read diseases from disease.txt
                string[] diseaseData = ReadFileLines(diseaseFilePath);

                // Create and populate the table
                CreateTable(diseaseData);
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Error loading disease data: {ex.Message}");
            }
        }

        private string[] ReadFileLines(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
                return new string[0];
            }
        }

        private void CreateTable(string[] diseaseData)
        {
            Table table = new Table { CssClass = "table table-bordered" };
            AddTableHeader(table, "Disease Name");

            foreach (var diseaseName in diseaseData)
            {
                if (!string.IsNullOrWhiteSpace(diseaseName))
                {
                    AddTableRow(table, diseaseName.Trim());
                }
            }

            phDiseaseTable.Controls.Add(table);
        }

        private void AddTableHeader(Table table, params string[] headers)
        {
            TableRow row = new TableRow();
            foreach (var header in headers)
            {
                TableCell cell = new TableCell { Text = header, CssClass = "fw-bold" };
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }

        private void AddTableRow(Table table, params string[] values)
        {
            TableRow row = new TableRow();
            foreach (var value in values)
            {
                TableCell cell = new TableCell { Text = value };
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }

        private void AppendDiseaseToFile(string filePath, string diseaseName)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.AppendAllText(filePath, $"{diseaseName};");
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write($"{diseaseName};");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        private void DeleteDiseaseFromFile(string filePath, string diseaseName)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] diseases = File.ReadAllText(filePath).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var disease in diseases)
                        {
                            if (!disease.Equals(diseaseName, StringComparison.OrdinalIgnoreCase))
                            {
                                writer.Write($"{disease};");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
