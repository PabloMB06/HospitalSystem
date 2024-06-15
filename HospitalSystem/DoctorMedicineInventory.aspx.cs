using HospitalSystem.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorMedicineInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicineData();
            }
        }

        private void LoadMedicineData()
        {
            string medicineFilePath = Server.MapPath("~/DB/medicine.txt");
            string pharmacyFilePath = Server.MapPath("~/DB/pharmacy.txt");

            if (File.Exists(medicineFilePath) && File.Exists(pharmacyFilePath))
            {
                string[] medicineData = File.ReadAllText(medicineFilePath).Split(';');
                string[] pharmacyData = File.ReadAllText(pharmacyFilePath).Split(';');
                var medicines = new List<Medicine>();

                Random random = new Random();
                foreach (var item in medicineData)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        medicines.Add(new Medicine
                        {
                            Name = item,
                            Pharmacy = GetRandomPharmacy(pharmacyData, random),
                            Amount = random.Next(10, 100).ToString(),
                            Prescription = DateTime.Now.AddDays(random.Next(-100, 0)) // Arrival date in the past
                        });
                    }
                }

                Table table = new Table { CssClass = "table table-bordered" };

                AddTableHeader(table, "Name", "Pharmacy", "Amount", "Arrival Date", "Expiry Date");

                foreach (var medicine in medicines)
                {
                    AddTableRow(table, medicine.Name, medicine.Pharmacy, medicine.Amount, medicine.PrescriptionFormatted, medicine.Prescription.AddYears(2).ToString("MM/dd/yyyy"));
                }

                phMedicineTable.Controls.Add(table);
            }
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

        private string GetRandomPharmacy(string[] pharmacies, Random random)
        {
            return pharmacies[random.Next(pharmacies.Length)];
        }

        protected void btnAddMedicine_Click(object sender, EventArgs e)
        {
            string newMedicine = txtNewMedicine.Text.Trim();
            if (!string.IsNullOrEmpty(newMedicine))
            {
                string medicineFilePath = Server.MapPath("~/DB/medicine.txt");
                AppendMedicineToFile(medicineFilePath, newMedicine);
                LoadMedicineData(); // Refresh the data displayed on the page
                txtNewMedicine.Text = ""; // Clear the text box
            }
        }

        protected void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            string medicineToDelete = txtNewMedicine.Text.Trim();
            if (!string.IsNullOrEmpty(medicineToDelete))
            {
                string medicineFilePath = Server.MapPath("~/DB/medicine.txt");
                DeleteMedicineFromFile(medicineFilePath, medicineToDelete);
                LoadMedicineData(); // Refresh the data displayed on the page
                txtNewMedicine.Text = ""; // Clear the text box
            }
        }

        private void AppendMedicineToFile(string filePath, string medicineName)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.AppendAllText(filePath, $"{medicineName};");
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write($"{medicineName};");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        private void DeleteMedicineFromFile(string filePath, string medicineName)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] medicines = File.ReadAllText(filePath).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var medicine in medicines)
                        {
                            if (!medicine.Equals(medicineName, StringComparison.OrdinalIgnoreCase))
                            {
                                writer.Write($"{medicine};");
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
