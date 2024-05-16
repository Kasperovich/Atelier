using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public DateTime ClosingDate { get; set;}
        //форма оплаты
        public bool FormOfPayment { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMaterial { get; set; } 
        public float CountCustomerMaterial { get; set; }
        public decimal PriceCustomerMaterial { get; set; }
        public string NameProduct { get; set; }
        public int CountProduct { get; set; }
        public int SizeProduct { get; set; }
        public int LongProduct1 { get; set; }
        public int LongProduct2 { get; set; }
        //Длинна рукова
        public int LongSleeve { get; set; }
        public double Coefficient { get; set; }
        public bool isClosed { get; set; }

        public int? Workerid { get; set; }
        public Worker Worker { get; set; }

        public List<Set> Sets { get; set; }
        public List<ListOfMaterial> ListOfMaterials { get; set; }
        public List<FinishingWork> FinishingWorks { get; set; }
        public List<ComplicatingElement> ComplicatingElements { get; set; }

        public Order()
        {
            Sets = new List<Set>();
            ListOfMaterials = new List<ListOfMaterial>();
            FinishingWorks = new List<FinishingWork>();
            ComplicatingElements = new List<ComplicatingElement>();
        }

    }
}
