using System;

namespace Atelier.Models
{
    public class ListOfMaterialReport
    {
        public string MaterialName { get; set; }
        public string MaterialUnit { get; set; }
        public decimal Price { get; set; }
        public double Quantiti { get; set; }
        public bool Type { get; set; }
        public int OrderId { get; set; }
        public int ProductCount { get; set; }
        public decimal Total { get { return Convert.ToDecimal((Price * Convert.ToDecimal(Quantiti)*ProductCount).ToString("F"));}}

        public ListOfMaterialReport(ListOfMaterial list)
        {
            MaterialName = list.Material.Name;
            MaterialUnit = list.Material.Unit;
            Price = list.Price;
            Quantiti = list.Quantity;
            Type = list.Material.Type;
        }
        public ListOfMaterialReport(ListOfMaterial list, int orderId, int productCount)
        {
            MaterialName = list.Material.Name;
            MaterialUnit = list.Material.Unit;
            Price = list.Price;
            Quantiti = list.Quantity;
            Type = list.Material.Type;
            OrderId = orderId;
            ProductCount = productCount;
        }
    }
}
