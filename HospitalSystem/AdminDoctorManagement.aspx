<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDoctorManagement.aspx.cs" Inherits="HospitalSystem.AdminDoctorManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor Management</title>
    <link href="Styles/AdminDoctorManagement.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5">
                <h1 class="text-center mb-4 text-white">Manage Professionals</h1>

                <!-- Navigation Buttons Grid -->
                <div class="row row-cols-1 row-cols-md-4 g-4">
                    <div class="col">
                        <a href="AdminDoctorList.aspx" class="btn btn-primary btn-block">List Doctors</a>
                    </div>
                    <div class="col">
                        <a href="#" class="btn btn-success btn-block">Create Doctor</a>
                    </div>
                    <div class="col">
                        <a href="#" class="btn btn-warning btn-block">Edit Doctor</a>
                    </div>
                    <div class="col">
                        <a href="#" class="btn btn-danger btn-block">Delete Doctor</a>
                    </div>
                </div>

            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    </form>
</body>
</html>
