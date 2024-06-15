<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDiseaseRecord.aspx.cs" Inherits="HospitalSystem.AdminDiseaseRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Disease Records</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center mb-4">Disease List</h1>
        <form id="form1" runat="server">
            <asp:PlaceHolder ID="phDiseaseTable" runat="server"></asp:PlaceHolder>
        </form>
    </div>
</body>
</html>
