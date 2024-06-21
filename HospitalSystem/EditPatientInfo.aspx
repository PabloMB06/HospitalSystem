<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPatientInfo.aspx.cs" Inherits="HospitalSystem.EditPatientInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Patient Info</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Styles/DoctorPatientManagement.css" rel="stylesheet" />
    <style>
        body {
            background-color: #0094ff; /* Cambia el color de fondo del cuerpo */
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
        <div class="container" align="center" >
             <h1 class="mb-4 text-center text-dark">Edit Patient Info</h1>
            <asp:Panel ID="pnlPatientInfo" runat="server">
                <div class="form-group">
                    <label for="txtName">Name<asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtLastName1">Last Name 1
                    <asp:TextBox ID="txtLastName1" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtLastName2">Last Name 2
                    <asp:TextBox ID="txtLastName2" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtNIC">NIC
                    <asp:TextBox ID="txtNIC" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtCivilStatus">Civil Status
                    <asp:TextBox ID="txtCivilStatus" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtBirthDate">Birth Date
                    <asp:TextBox ID="txtBirthDate" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtPhone">Phone
                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Email
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <div class="form-group">
                    <label for="txtResidency">Residency
                    <asp:TextBox ID="txtResidency" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                 <div class="form-group">
                    <label for="ddlDisease">Disease
                        <asp:DropDownList ID="ddlDisease" runat="server" CssClass="form-select"></asp:DropDownList>
                    </label>
                </div>
                <div class="form-group">
                    <label for="txtMedicine">Medicine
                    <asp:TextBox ID="txtMedicine" CssClass="form-control" runat="server"></asp:TextBox></label>
                </div>
                <br></br>
                <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Confirm Changes" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure you want to save changes?');" />
                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click"  OnClientClick="return confirm('Are you sure you want to cancel?');" />
            </asp:Panel>
            <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
