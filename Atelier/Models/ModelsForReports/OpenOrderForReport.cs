using System;

namespace Atelier.Models.ModelsForReports
{
    public class OpenOrderForReport
    {
        public int OrderId { get; set;}
        public string ReceiptNumber { get; set; }
        public string DateOfReceipt { get; set; }
        public string NameProduct { get; set; }
        public double Coefficient { get; set; }
        public decimal OrderPrice { get; set; }
        public int WorkerId { get; set; }

        public OpenOrderForReport(Order _order, decimal _orderPrice)
        {
            OrderId = _order.OrderId;
            ReceiptNumber = _order.ReceiptNumber;
            DateOfReceipt = _order.DateOfReceipt.ToString("dd/MM/yyyy");
            NameProduct = _order.NameProduct;
            Coefficient = _order.Coefficient;
            WorkerId = (int)_order.Workerid;
            OrderPrice = _orderPrice;
        }
    }
}
