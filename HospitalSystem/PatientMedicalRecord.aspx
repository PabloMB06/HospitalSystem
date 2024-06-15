<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientMedicalRecord.aspx.cs" Inherits="HospitalSystem.PatientMedicalRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Medical Record</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/PatientMedicalRecord.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5">
                <h1 class="text-center mb-4 text-white">Medical Record</h1>
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <asp:PlaceHolder ID="phPatientTable" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    </form>
</body>
</html>
