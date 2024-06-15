<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorDiseaseRecord.aspx.cs" Inherits="HospitalSystem.DoctorDiseaseRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor - Disease Records</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/DoctorDiseaseRecord.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <div class="background">
        <div class="container mt-5">
            <h1 class="text-center mb-4">Disease List</h1>
            <form id="form1" runat="server">
                <div class="mb-3">
                    <asp:TextBox ID="txtNewDisease" runat="server" CssClass="form-control" placeholder="Enter disease name"></asp:TextBox>
                </div>
                <div class="mb-3 text-center">
                    <asp:Button ID="btnAddDisease" runat="server" Text="Add Disease" CssClass="btn btn-primary" OnClick="btnAddDisease_Click" />
                    <asp:Button ID="btnDeleteDisease" runat="server" Text="Delete Disease" CssClass="btn btn-danger" OnClick="btnDeleteDisease_Click" />
                </div>
                <asp:PlaceHolder ID="phDiseaseTable" runat="server"></asp:PlaceHolder>
            </form>
        </div>
    </div>
</body>
</html>
