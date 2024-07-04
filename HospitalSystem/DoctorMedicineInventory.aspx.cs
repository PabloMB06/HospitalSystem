using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DoctorMedicineInventory : Page
{
    private string filePath = HttpContext.Current.Server.MapPath("~/DB/medicine.txt");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMedicines();
        }
    }

    private void LoadMedicines()
    {
        List<Medicine> medicines = new List<Medicine>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        medicines.Add(new Medicine
                        {
                            Name = parts[0].Trim(),
                            Pharmacy = parts[1].Trim(),
                            Quantity = int.Parse(parts[2].Trim())
                        });
                    }
                }
            }
        }
        gvMedicines.DataSource = medicines;
        gvMedicines.DataBind();
    }

    protected void btnAddMedicine_Click(object sender, EventArgs e)
    {
        string name = txtNewMedicineName.Text.Trim();
        string pharmacy = txtNewMedicinePharmacy.Text.Trim();
        int quantity;
        if (int.TryParse(txtNewMedicineQuantity.Text.Trim(), out quantity))
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{name}, {pharmacy}, {quantity}");
            }
            txtNewMedicineName.Text = string.Empty;
            txtNewMedicinePharmacy.Text = string.Empty;
            txtNewMedicineQuantity.Text = string.Empty;
            LoadMedicines();
        }
    }

    protected void gvMedicines_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string medicineToDelete = gvMedicines.DataKeys[e.RowIndex].Value.ToString();
        List<string> lines = new List<string>(File.ReadAllLines(filePath));
        lines.RemoveAll(line => line.StartsWith(medicineToDelete, StringComparison.OrdinalIgnoreCase));
        File.WriteAllLines(filePath, lines);
        LoadMedicines();
    }

    public class Medicine
    {
        public string Name { get; set; }
        public string Pharmacy { get; set; }
        public int Quantity { get; set; }
    }
}
