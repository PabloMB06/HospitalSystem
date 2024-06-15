<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="HospitalSystem.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/AdminDashboard.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5">
                <h1 class="text-center mb-4 text-white">Admin Dashboard</h1>
                <div class="row justify-content-center">
                    <div class="col-md-6 text-center">
                        <asp:Button ID="btnAdminPatientManagement" runat="server" Text="Manage Patients" CssClass="btn btn-primary mb-3 w-100" OnClick="btnAdminPatientManagement_Click" />
                        <asp:Button ID="btnAdminDoctorManagement" runat="server" Text="Manage Doctors" CssClass="btn btn-info mb-3 w-100" OnClick="btnAdminDoctorManagement_Click" />
                        <asp:Button ID="btnAdminMedicineInventory" runat="server" Text="Manage Medicines" CssClass="btn btn-warning mb-3 w-100" OnClick="btnAdminMedicineInventory_Click" />
                        <asp:Button ID="btnAdminDiseaseRecord" runat="server" Text="Manage Disease Records" CssClass="btn btn-secondary mb-3 w-100" OnClick="btnAdminDiseaseRecord_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
