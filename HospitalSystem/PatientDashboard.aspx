<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientDashboard.aspx.cs" Inherits="HospitalSystem.PatientDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient - Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/PatientDashboard.css" rel="stylesheet" />
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center mb-4">Medical Record</h1>
        <form id="form1" runat="server">
            <asp:PlaceHolder ID="phPatientTable" runat="server"></asp:PlaceHolder>
        </form>
    </div>
</body>
</html>
