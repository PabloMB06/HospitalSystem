<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorMedicineInventory.aspx.cs" Inherits="DoctorMedicineInventory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventario de Medicamentos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            margin-top: 30px;
        }
        h1 {
            text-align: center;
            color: #4CAF50;
        }
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .gridview th, .gridview td {
            padding: 10px;
            text-align: left;
        }
        .gridview th {
            background-color: #4CAF50;
            color: white;
        }
        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .input-group {
            margin-top: 20px;
            text-align: center;
        }
        .input-group input[type="text"] {
            padding: 10px;
            width: 25%;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-right: 10px;
        }
        .input-group button {
            padding: 10px 20px;
            background-color: #4CAF50;
            border: none;
            color: white;
            border-radius: 4px;
            cursor: pointer;
        }
        .input-group button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Inventario de Medicamentos</h1>
            <asp:GridView ID="gvMedicines" runat="server" AutoGenerateColumns="False" DataKeyNames="Name" CssClass="gridview" OnRowDeleting="gvMedicines_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Medicamento" ReadOnly="True" />
                    <asp:BoundField DataField="Pharmacy" HeaderText="Farmacia" ReadOnly="True" />
                    <asp:BoundField DataField="Quantity" HeaderText="Cantidad Disponible" ReadOnly="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <div class="input-group">
                <asp:TextBox ID="txtNewMedicineName" runat="server" Placeholder="Nombre del Medicamento"></asp:TextBox>
                <asp:TextBox ID="txtNewMedicinePharmacy" runat="server" Placeholder="Farmacia"></asp:TextBox>
                <asp:TextBox ID="txtNewMedicineQuantity" runat="server" Placeholder="Cantidad"></asp:TextBox>
                <asp:Button ID="btnAddMedicine" runat="server" Text="Agregar Medicamento" OnClick="btnAddMedicine_Click" />
            </div>
        </div>
    </form>
</body>
</html>
