using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class AdminDiseaseRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiseaseData();
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
                return File.ReadAllText(filePath).Split(';');
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
    }
}
