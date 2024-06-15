﻿using HospitalSystem.Objects;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorPatientManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicalRecords();
            }
        }

        private void LoadMedicalRecords()
        {
            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
            string diseaseFilePath = Server.MapPath("~/DB/disease.txt");
            string medicineFilePath = Server.MapPath("~/DB/medicine.txt");

            if (File.Exists(patientFilePath) && File.Exists(doctorFilePath) && File.Exists(diseaseFilePath) && File.Exists(medicineFilePath))
            {
                string[] lines = File.ReadAllLines(patientFilePath);

                foreach (string line in lines)
                {
                    string[] patientData = line.Split(';');

                    if (patientData.Length >= 9) // Ensure there are enough fields to read
                    {
                        Patient patient = new Patient
                        {
                            Name = patientData[0],
                            LastName1 = patientData[1],
                            LastName2 = patientData[2],
                            NIC = patientData[3],
                            CivilStatus = patientData[4],
                            BirthDate = patientData[5],
                            Phone = patientData[6],
                            Email = patientData[7],
                            Residency = patientData[8]
                        };

                        // Read doctor data (assuming it's from the same structure as patient data)
                        string[] doctorData = File.ReadAllText(doctorFilePath).Split(';');
                        Doctor doctor = new Doctor
                        {
                            Name = doctorData[0],
                            LastName1 = doctorData[1],
                            LastName2 = doctorData[2],
                            Specialty = doctorData[8]
                        };

                        // Get random disease and medicine
                        string diseaseName = GetRandomEntryFromFile(diseaseFilePath);
                        string medicineName = GetRandomEntryFromFile(medicineFilePath);

                        Disease disease = new Disease
                        {
                            Name = diseaseName
                        };

                        Medicine medicine = new Medicine
                        {
                            Name = medicineName,
                            Prescription = DateTime.Now
                        };

                        MedicalRecord medicalRecord = new MedicalRecord
                        {
                            Doctor = doctor,
                            Patient = patient,
                            Disease = disease,
                            Medicine = medicine
                        };

                        // Simulate appointments
                        Appointment lastAppointment = new Appointment { Visit = DateTime.Now.AddDays(-30) };
                        Appointment nextAppointment = new Appointment { Visit = DateTime.Now.AddDays(30) };

                        // Create and populate table
                        Table table = new Table { CssClass = "table table-bordered mb-4" };

                        AddTableRow(table, "Name", medicalRecord.Patient.Name);
                        AddTableRow(table, "Last Name 1", medicalRecord.Patient.LastName1);
                        AddTableRow(table, "Last Name 2", medicalRecord.Patient.LastName2);
                        AddTableRow(table, "NIC", medicalRecord.Patient.NIC);
                        AddTableRow(table, "Civil Status", medicalRecord.Patient.CivilStatus);
                        AddTableRow(table, "Birth Date", medicalRecord.Patient.BirthDate);
                        AddTableRow(table, "Phone", medicalRecord.Patient.Phone);
                        AddTableRow(table, "Email", medicalRecord.Patient.Email);
                        AddTableRow(table, "Residency", medicalRecord.Patient.Residency);
                        AddTableRow(table, "Disease", medicalRecord.Disease.Name);
                        AddTableRow(table, "Medicine", $"{medicalRecord.Medicine.Name} (Prescribed on: {medicalRecord.Medicine.PrescriptionFormatted})");
                        AddTableRow(table, "Doctor", $"{medicalRecord.Doctor.Name} {medicalRecord.Doctor.LastName1} {medicalRecord.Doctor.LastName2} - {medicalRecord.Doctor.Specialty}");
                        AddTableRow(table, "Last Appointment", lastAppointment.VisitFormatted);
                        AddTableRow(table, "Upcoming Appointments", nextAppointment.VisitFormatted);

                        // Add the table to the placeholder
                        phPatientTable.Controls.Add(table);
                    }
                }
            }
        }

        private void AddTableRow(Table table, string header, string value)
        {
            TableRow row = new TableRow();
            TableCell cellHeader = new TableCell { Text = header, CssClass = "fw-bold" };
            TableCell cellValue = new TableCell { Text = value };

            row.Cells.Add(cellHeader);
            row.Cells.Add(cellValue);
            table.Rows.Add(row);
        }

        private string GetRandomEntryFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] entries = File.ReadAllText(filePath).Split(';');
                Random random = new Random();
                return entries[random.Next(entries.Length)];
            }
            return "Unknown";
        }
    }
}
