using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DoctorDiseaseRecord : Page
{
    private string filePath = HttpContext.Current.Server.MapPath("~/DB/disease.txt");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDiseases();
        }
    }

    private void LoadDiseases()
    {
        List<Disease> diseases = new List<Disease>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    diseases.Add(new Disease { Name = line });
                }
            }
        }
        gvDiseases.DataSource = diseases;
        gvDiseases.DataBind();
    }

    protected void btnAddDisease_Click(object sender, EventArgs e)
    {
        string newDisease = txtNewDisease.Text.Trim();
        if (!string.IsNullOrEmpty(newDisease))
        {
            File.AppendAllLines(filePath, new[] { newDisease });
            txtNewDisease.Text = string.Empty;
            LoadDiseases();
        }
    }

    protected void gvDiseases_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string diseaseToDelete = gvDiseases.DataKeys[e.RowIndex].Value.ToString();
        List<string> lines = new List<string>(File.ReadAllLines(filePath));
        lines.RemoveAll(line => line.Equals(diseaseToDelete, StringComparison.OrdinalIgnoreCase));
        File.WriteAllLines(filePath, lines);
        LoadDiseases();
    }

    public class Disease
    {
        public string Name { get; set; }
    }
}
