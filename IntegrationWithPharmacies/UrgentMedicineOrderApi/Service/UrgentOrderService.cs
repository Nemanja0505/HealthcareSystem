﻿using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Repository;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Dto;
using UrgentMedicineOrderApi.Adapter;


namespace UrgentMedicineOrderApi.Service
{
    public class UrgentOrderService
    {
        private HttpRequests HttpService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        public UrgentMedicineOrderRepository UrgentMedicineOrderRepository { get; }
        public IUrgentMedicineOrderRepository IUrgentMedicineOrderRepository { get; }
        public UrgentOrderService(MyDbContext context)
        {
            HttpService = new HttpRequests();
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
            UrgentMedicineOrderRepository = new UrgentMedicineOrderRepository(context);
        }

        public UrgentOrderService(IUrgentMedicineOrderRepository urgentMedicineOrderRepository)
        {
            IUrgentMedicineOrderRepository = urgentMedicineOrderRepository;
        }

        public UrgentMedicineOrder Create(UrgentMedicineOrderDto dto)
        {
            return UrgentMedicineOrderRepository.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderDtoUrgentMedicineOrder(dto));
        }

        public List<UrgentMedicineOrder> GetAll()
        {
            return UrgentMedicineOrderRepository.GetAll();
        }
        public List<UrgentMedicineOrder> GetAllForStub()
        {
            return IUrgentMedicineOrderRepository.GetAll();
        }
        public UrgentMedicineOrder createIUrgentMedicineOrder(UrgentMedicineOrderDto dto)
        {
            return UrgentMedicineOrderAdapter.UrgentMedicineOrderDtoUrgentMedicineOrder(dto);
        }
        public Boolean SendOrderHttp(UrgentMedicineOrder order)
        {
            try
            {
                HttpService.SendUrgentOrder(CreateOrder(order));
                return true;
            }
            catch (Exception e) { return false; }
        }
        public Boolean SendOrderGrpc(UrgentMedicineOrder order)
        {
            try
            {
                _= new ClientScheduledService().SendMessage(CreateOrder(order)).Result;
                return true;
            }
            catch (Exception e) { return false; }
        }
        public String CreateOrder(UrgentMedicineOrder order)
        {
            return order.Name + ":"+ order.Quantity.ToString()+":"+order.Pharmacy;

        }
        public static UrgentMedicineOrder CreateUrgentOrder(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            String[] parts = medicine.Split("_");

            return new UrgentMedicineOrder(parts[0], int.Parse(parts[1]), pharmaciesWithMedicine[0].Api, DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public List<MedicineName> CheckMedicineAvailability(string medicine)
        {
            return MedicineAvailabilityTable.FormMedicineAvailability(HttpRequests.FormMedicineAvailabilityRequest(medicine));
        }
    }
}
