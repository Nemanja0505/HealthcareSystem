﻿using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Service;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Adapter;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace UrgentMedicineOrderApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : Controller
    {
        private UrgentOrderService UrgentOrderService { get; }

        public UrgentOrderController(MyDbContext context)
        {
            UrgentOrderService = new UrgentOrderService(context);
        }

        [HttpGet("http/{medicine}")]
        public IActionResult FormUrgentOrderHttp(String medicine)
        {
            List<MedicineName> pharmaciesWithMedicine = UrgentOrderService.CheckMedicineAvailability(medicine);
            if (pharmaciesWithMedicine == null) return BadRequest();
            UpdateMedicineQuantity(medicine);
            return ForwardUrgentUrderHttp(medicine, pharmaciesWithMedicine);
        }

        [HttpGet("grpc/{medicine}")]
        public IActionResult FormUrgentOrderGrpc(String medicine)
        {
            List<MedicineName> pharmaciesWithMedicine = UrgentOrderService.CheckMedicineAvailability(medicine);
            if (pharmaciesWithMedicine == null) return BadRequest();
            UpdateMedicineQuantity(medicine);
            return ForwardUrgentUrderGrpc(medicine, pharmaciesWithMedicine);
        }

        private void UpdateMedicineQuantity(string medicine)
        {
            var client = new RestSharp.RestClient("http://localhost:54679");
            var medicineUpdate = client.Put(new RestRequest("/api/medicineWithQuantity/"+medicine));
        }

        private IActionResult ForwardUrgentUrderHttp(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            UrgentMedicineOrder urgentMedicineOrder = UrgentOrderService.CreateUrgentOrder(medicine, pharmaciesWithMedicine);
            if (UrgentOrderService.SendOrderHttp(urgentMedicineOrder)) return CretaeUrgentOrder(pharmaciesWithMedicine, urgentMedicineOrder);
            return BadRequest();
        }
        private IActionResult ForwardUrgentUrderGrpc(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            UrgentMedicineOrder urgentMedicineOrder = UrgentOrderService.CreateUrgentOrder(medicine, pharmaciesWithMedicine);
            if (UrgentOrderService.SendOrderGrpc(urgentMedicineOrder)) return CretaeUrgentOrder(pharmaciesWithMedicine, urgentMedicineOrder);
            return BadRequest();
        }

        private IActionResult CretaeUrgentOrder(List<MedicineName> pharmaciesWithMedicine, UrgentMedicineOrder urgentMedicineOrder)
        {
            UrgentOrderService.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderToUrgentMedicineOrderDto(urgentMedicineOrder));
            return Ok(pharmaciesWithMedicine[0].Name);
        }
    }
}
