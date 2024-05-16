using System;
using System.Collections.Generic;

namespace Atelier.Models
{
    public class OrderForReport
    {
        public int OrderId { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime DateOfReceipt { get; set; }

        public OrderForReport(string receiptNumber, DateTime dateOfReceipt, int orderId)
        {
            ReceiptNumber = receiptNumber;
            DateOfReceipt = dateOfReceipt;
            OrderId = orderId;
        }
    }
}
