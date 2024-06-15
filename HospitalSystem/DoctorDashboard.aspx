<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorDashboard.aspx.cs" Inherits="HospitalSystem.DoctorDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor - Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/DoctorDashboard.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5 text-center">
                <h1 class="mb-4 text-white">My Workspace</h1>
                <div class="btn-group-vertical">
                    <asp:Button ID="btnGoToPatientManagement" runat="server" Text="Manage Patients" CssClass="btn btn-primary mb-3 btn-lg" OnClick="btnGoToPatientManagement_Click" />
                    <asp:Button ID="btnGoToMedicineInventory" runat="server" Text="Manage Medicines" CssClass="btn btn-primary mb-3 btn-lg" OnClick="btnGoToMedicineInventory_Click" />
                    <asp:Button ID="btnGoToDiseaseRecord" runat="server" Text="Manage Diseases" CssClass="btn btn-primary mb-3 btn-lg" OnClick="btnGoToDiseaseRecord_Click" />
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
