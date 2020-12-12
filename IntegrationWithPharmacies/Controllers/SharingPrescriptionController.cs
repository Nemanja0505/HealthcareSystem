﻿using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace IntegrationWithPharmacies.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SharingPrescriptionController : Controller
    {
        private String Environment { get; set; }
        private MedicineService MedicineService { get; set; }
        private PatientService PatientService { get; set; }
        public SharingPrescriptionController(MyDbContext context)
        {
            MedicineService = new MedicineService(context);
            PatientService = new PatientService(context);
            Environment = "Local"; 
        }

        [HttpGet("patients")]
        public IActionResult GetPatients()
        {
            return Ok(PatientService.GetAll());
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MedicineService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Prescription prescription)
        {
            if (Environment.Equals("Local"))
            {
                return sendPrescriptionSftp(prescription);
            }
            return BadRequest();
        }

        private IActionResult sendPrescriptionSftp(Prescription prescription)
        {
            var testFile = @"..\test.txt";
            var sftpService = new SftpService(new NullLogger<SftpService>(), getConfig());
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + getRandomNumber() + ".txt";
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            System.IO.File.WriteAllText(complete, getTextForPrescription(prescription));
            sftpService.UploadFile(testFile, @"\pub\" + complete);
            SendNotificationAboutReport();
            return Ok();
        }

        private int getRandomNumber()
        {
            return new Random().Next(1, 100);
        }
        private String getTextForPrescription(Prescription prescription)
        {
            StringBuilder stringBuilder = new StringBuilder();
            return stringBuilder.Append("          Precription for medicine\n\nPatients name: " + prescription.Name + "\nPatients surname: " + prescription.Surname + "\nPatients medical ID number: " + prescription.MedicalIDNumber + "\nMedication: " + prescription.Medicine + "     Quantity: " + prescription.Quantity + "\nUsage: " + prescription.Usage + "\n").ToString();
         
        }
        [HttpPost("http")]
        public IActionResult PostHttp(Prescription prescription)
        {
            if (Environment.Equals("Development"))
            {
                return sendPrescriptionHttp(prescription);
            }
            return BadRequest();
        }

        private IActionResult sendPrescriptionHttp(Prescription prescription)
        {
            var testFile = @"..\test.txt";
            String complete = @"FilePrescriptions\..\Prescription" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + getRandomNumber() + ".txt";
            System.IO.FileStream fs = System.IO.File.Create(complete);
            fs.Close();
            System.IO.File.WriteAllText(complete, getTextForPrescription(prescription));
            try
            {
                uploadFile(complete);
                return Ok(JsonConvert.SerializeObject(testFile));
            }
            catch (Exception e)
            {

            }
            return Ok();
        }

        public void uploadFile(String complete)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(@"http://localhost:8082/download/prescription/http");
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(uri, "POST", complete);
            client.Dispose();
            SendNotificationAboutReport();
        }

        public void SendNotificationAboutReport()
        {
            try
            {
                sendEmail();
            }
            catch (SmtpException ex) {
              
            }

        }

        private static void sendEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmptServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("ourhospital9@gmail.com");
            mail.To.Add("pharmacyisa@gmail.com");
            mail.Subject = "Notification about sent file";
            mail.Body = "Body of mail address";
            SmptServer.Port = 587;
            SmptServer.Credentials = new System.Net.NetworkCredential("ourhospital9@gmail.com", "hospital.9");
            SmptServer.EnableSsl = true;
            SmptServer.Send(mail);
        }

        private SftpConfig getConfig()
        {
            return new SftpConfig { Host = "192.168.1.244", Port = 22, UserName = "tester", Password = "password" };
        }

    }
}
