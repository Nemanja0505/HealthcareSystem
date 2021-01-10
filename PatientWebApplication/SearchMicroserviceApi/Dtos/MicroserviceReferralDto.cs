﻿using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroserviceReferralDto : Entity
    {
        public string Medicine { get; set; }
        public string TakeMedicineUntil { get; set; }
        public int QuantityPerDay { get; set; }
        public string Classify { get; set; }
        public string Comment { get; set; }
        public int AppointmentId { get; set; }

        public MicroserviceReferralDto() : base() { }
        public MicroserviceReferralDto(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment) : base(id)

        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;
        }

        public MicroserviceReferralDto(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment, int appointmentId) : base(id)

        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;
            AppointmentId = appointmentId;
        }
    }
}
