<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalSystem.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User - Login</title>
    <link href="Styles/Login.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body class="login-bg">
    <form id="loginForm" runat="server">
        <div class="container-fluid">
            <div class="row justify-content-center align-items-center" style="height: 100vh;">
                <div class="col-md-4">
                    <div class="card bg-light">
                        <div class="card-body">
                            <h2 class="text-center mb-4">Login</h2>
                            <div class="mb-3">
                                <label for="txtEmail" class="form-label">Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="mb-3">
                                <label for="txtPassword" class="form-label">Password:</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="d-block text-center" />
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary w-100" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
