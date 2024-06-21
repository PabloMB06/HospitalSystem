<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorPatientManagement.aspx.cs" Inherits="HospitalSystem.DoctorPatientManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor - Patient Management</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/DoctorPatientManagement.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5">
                <h1 class="mb-4 text-white">Patient Management</h1>

                <!-- Form for adding/editing patient -->
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Add/Edit Patient</h5>
                        <div class="mb-3">
                            <label for="txtName" class="form-label">Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLastName1" class="form-label">Last Name 1</label>
                            <asp:TextBox ID="txtLastName1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLastName2" class="form-label">Last Name 2</label>
                            <asp:TextBox ID="txtLastName2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtNIC" class="form-label">NIC</label>
                            <asp:TextBox ID="txtNIC" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtCivilStatus" class="form-label">Civil Status</label>
                            <asp:TextBox ID="txtCivilStatus" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtBirthDate" class="form-label">Birth Date</label>
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtPhone" class="form-label">Phone</label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtEmail" class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtResidency" class="form-label">Residency</label>
                            <asp:TextBox ID="txtResidency" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="btnAddPatient" runat="server" Text="Add Patient" CssClass="btn btn-primary" OnClick="btnAddPatient_Click" />                  
                            <asp:Button ID="btnBack" runat="server" Text="Go Back" CssClass="btn btn-danger ms-2" OnClick="btnBack_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
