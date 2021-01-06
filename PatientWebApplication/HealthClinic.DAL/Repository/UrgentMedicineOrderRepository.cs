﻿using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
   public class UrgentMedicineOrderRepository : IUrgentMedicineOrderRepository
    {
        private MyDbContext dbContext;
        public UrgentMedicineOrderRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public UrgentMedicineOrderRepository() { }
        public UrgentMedicineOrder Create(UrgentMedicineOrder order)
        {
            this.dbContext.UrgentMedicineOrder.Add(order);
            this.dbContext.SaveChanges();
            return order;
        }

        public List<UrgentMedicineOrder> GetAll()
        {
            return this.dbContext.UrgentMedicineOrder.ToList();
        }
    }
}