<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientDashboard.aspx.cs" Inherits="HospitalSystem.PatientDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient - Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/PatientDashboard.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5 text-center">
                <h1 class="mb-4 text-white">Welcome to Your Dashboard</h1>
                <asp:Button ID="btnGoToMedicalRecord" runat="server" Text="View Medical Record" CssClass="btn btn-primary mb-3" OnClick="btnGoToMedicalRecord_Click" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
