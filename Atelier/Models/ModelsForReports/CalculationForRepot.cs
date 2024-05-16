using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class CalculationForRepot
    {
        public Order order;
        public decimal costOfSewingPrice;
        public string orderSumm;
        public List<ListOfMaterialReport> materials;
        public List<AditionalElement> elements;

        public CalculationForRepot()
        {
            materials = new List<ListOfMaterialReport>();
            elements = new List<AditionalElement>();
        }
    }
}
