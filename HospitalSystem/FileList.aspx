<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="HospitalSystem.FileList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient List</title>
    <link href="Styles/FileList.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
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
            <h2 class="mb-4 text-center text-dark">Patient List</h2>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
            <asp:Table ID="tblPatientList" runat="server" CssClass="table table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Patient Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

        <!-- Modal for delete confirmation -->
        <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="deleteModalLabel">Confirm Delete</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Are you sure you want to delete all information for this patient?
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmDelete" runat="server" Text="Yes" CssClass="btn btn-danger" OnClick="btnConfirmDelete_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hfPatientIdToDelete" runat="server" />
    </form>
    <script type="text/javascript">
        function showDeleteModal(patientId) {
            $('#<%= hfPatientIdToDelete.ClientID %>').val(patientId);
            $('#deleteModal').modal('show');
        }
    </script>
</body>
</html>
