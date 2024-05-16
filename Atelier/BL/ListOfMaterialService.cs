using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    public static class ListOfMaterialService
    {
        public static decimal GetSumMaterialsByWorkerIdAndFormOfPayment(int workerId, bool formOfPayment)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();

            var sum = Math.Round(listRepo.GetAll()
                                      .Where(l => l.order.Workerid == workerId && 
                                                  l.order.isClosed == false &&
                                                  l.order.FormOfPayment == formOfPayment)
                                      .Sum(l => l.Price * (decimal)l.Quantity * l.order.CountProduct),2);
            return sum;
        }

        public static List<ListOfMaterialReport> GetListOfMaterialReports(int orderId)
        {
            var orderMaterials = GetByOrderId(orderId);
            List<ListOfMaterialReport> materialsforReport = new List<ListOfMaterialReport>();
            foreach (ListOfMaterial orderMaterial in orderMaterials)
            {
                materialsforReport.Add(new ListOfMaterialReport(orderMaterial));
            }
            return materialsforReport;
        }
        public static decimal GetSumMaterialsByMaterialIdAndPrice(int materialId, decimal price)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return Math.Round(listRepo.GetAll().Where(l => l.MaterialId == materialId && l.Price == price).Sum(l => l.Price * (decimal)l.Quantity * l.order.CountProduct),2);
        }
        public static List<ListOfMaterial> GetMaterialsByMaterialIdAndPrice(int materialId, decimal price)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            var materials = listRepo.GetAll().Where(l => l.MaterialId == materialId && l.Price == price).ToList();
            return materials;
        }
        public static decimal GetSumMaterialsByOrderId(int orderId)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return Math.Round(listRepo.GetByOrderId(orderId).Sum(s => s.Price*(decimal)s.Quantity*s.order.CountProduct),2);   
        }
        public static List<MaterialForReport> GetAllGroupByIdAndPrice(DateTime firstDate, DateTime lastDate)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return listRepo.GetAll().Where(l=>l.order.DateOfReceipt >= firstDate && l.order.DateOfReceipt <= lastDate)
                                    .GroupBy(l => new { l.MaterialId, l.Price })
                                    .Select(l => new MaterialForReport()
                                    {
                                        MaterialId = (int)l.Key.MaterialId,
                                        Price = l.Key.Price,
                                        MaterialName = MaterialService.getNameById((int)l.Key.MaterialId),
                                        Type = MaterialService.getTypeById((int)l.Key.MaterialId),
                                    })
                                    .ToList();
        }
        public static decimal MaterialsPriceByOrderIdAndMaterialType(int orderId, bool type)
        {
            decimal materialsPrice = 0;
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            var materials = listRepo.getMaterialsByOrderId(orderId).Where(m=>m.Material.Type == type);
            foreach (ListOfMaterial list in materials)
            {
                materialsPrice += list.Price * Convert.ToDecimal(list.Quantity);
            }
            return materialsPrice;
        }

        public static decimal MaterialsPriceByOrderId(int orderId)
        {
            decimal materialsPrice = 0;
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            var materials = listRepo.getMaterialsByOrderId(orderId);
            foreach (ListOfMaterial list in materials)
            {
                materialsPrice += list.Price * Convert.ToDecimal(list.Quantity);
            }
            return materialsPrice;
        }

        public static ListOfMaterial GetById(int listId)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return listRepo.GetById(listId);
        }
        public static List<ListOfMaterial> GetByOrderId(int orderId)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return listRepo.GetByOrderId(orderId);
        }

        public static string Create(ListOfMaterial list)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return listRepo.Create(list);
        }

        public static string Update(ListOfMaterial list)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return listRepo.Update(list);
        }

        public static string Delete(int listId)
        {
            ListOfMaterialRepository listRepo = new ListOfMaterialRepository();
            return listRepo.Delete(listId);
        }
    }
}
