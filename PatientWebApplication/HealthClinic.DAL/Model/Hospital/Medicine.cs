/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;


namespace HealthClinic.CL.Model.Hospital
{
    public class Medicine : Equipment
    {
        public List<ModelRoom> room { get; set; }
        public int doctorId { get; set; }
        public virtual DoctorUser doctor { get; set; }
        public string description { get; set; }
        public bool isConfirmed { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, DoctorUser doctor, bool isConfirmed) : base(id, name, quantity, room)
        {
            this.doctor = doctor;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isConfirmed) : base(id, name, quantity, room)
        {
            this.doctorId = doctorId;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isConfirmed, int prescriptionId) : base(id, name, quantity, room)
        {
            this.doctorId = doctorId;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
            this.PrescriptionId = prescriptionId;
        }

        public Medicine(int id, string name, int quantity, string description, List<ModelRoom> room, DoctorUser doctor, bool isConfirmed, Prescription prescription) : base(id, name, quantity, room)
        {
            this.doctor = doctor;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
            this.Prescription = prescription;
            this.PrescriptionId = prescription.id;
        }

        public Medicine() : base()
        {
        }
    }
}