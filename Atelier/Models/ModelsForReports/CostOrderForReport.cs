using System;

namespace Atelier.Models
{
    public class CostOrder
    {
        public string ReceiptNumber { get;  }
        public string NameProduct { get; }
        public string CustomerName { get;  }
        //стоимость основных материалов
        public decimal BasicMaterialsPrice { get;  }
        //Стоимость прикладных материалов
        public decimal ApliedMaterialPrice { get;  }
        //Стоимость пошива
        public decimal CostOfSewin { get;  }
        //Общая сумма заказа
        public decimal OrderSum { get { return CostOfSewin + BasicMaterialsPrice + ApliedMaterialPrice; } }

        public CostOrder(string _receiptNumber, 
                            string _nameProduct,
                            string _customerName,
                            decimal _basicMaterialsPrice,
                            decimal _apliedMaterialPrice,
                            decimal _costOfSewin)
        {
            ReceiptNumber = _receiptNumber;
            NameProduct = _nameProduct;
            CustomerName = _customerName;
            BasicMaterialsPrice = _basicMaterialsPrice;
            ApliedMaterialPrice = _apliedMaterialPrice;
            CostOfSewin = Convert.ToDecimal(_costOfSewin.ToString("F"));
        }
    }
}
