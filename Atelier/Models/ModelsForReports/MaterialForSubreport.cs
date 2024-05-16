using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models.ModelsForReports
{
    public class MaterialForSubreport
    {
        public string ReceiptNumber { get; set; }
        public decimal Price { get; set; }
        public double Count { get; set; }
        public int idMaterial { get; set; }

        public MaterialForSubreport(ListOfMaterial material)
        {
            ReceiptNumber = material.order.ReceiptNumber;
            Price = material.Price;
            Count = material.Quantity*material.order.CountProduct;
            idMaterial = (int)material.MaterialId;
        }
    }
}
