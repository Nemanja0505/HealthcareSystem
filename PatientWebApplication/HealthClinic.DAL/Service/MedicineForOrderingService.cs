﻿using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class MedicineForOrderingService
    {
        public MedicineForOrderingRepository MedicineForOrderingRepository { get; }
        public MedicineForOrderingService() { }

        public MedicineForOrderingService(MyDbContext context)
        {
            MedicineForOrderingRepository = new MedicineForOrderingRepository(context);
        }
        public List<MedicineForOrdering> GetAll()
        {
            return MedicineForOrderingRepository.GetAll();
        }
        public MedicineForOrdering Create(MedicineForOrderingDto dto)
        {
            MedicineForOrdering medicine = MedicineForOrderingAdapter.MedicineOrderDtoToMedicineOrder(dto);
            return MedicineForOrderingRepository.Create(medicine);
        }
    }
}