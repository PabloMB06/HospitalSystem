<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorPatientList.aspx.cs" Inherits="HospitalSystem.DoctorPatientList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor - Patient List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Styles/DoctorPatientManagement.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa; /* Cambia el color de fondo del cuerpo */
        }

        .container {
            margin-top: 50px; /* Ajusta el margen superior del contenedor */
        }

        .btn-back {
            margin-top: 20px; /* Ajusta el margen superior del botón */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="mb-4 text-center text-dark">Patient File</h1>
            <asp:PlaceHolder ID="phPatientTable" runat="server"></asp:PlaceHolder>
        </div>
        <div class="text-center">
            <asp:Button ID="btnBack" runat="server" Text="Back to Patient Management" CssClass="btn btn-danger btn-back" OnClick="btnBack_Click" />
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
