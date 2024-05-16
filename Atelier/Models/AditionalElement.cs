using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class AditionalElement
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public AditionalElement(ComplicatingElement elemnt)
        {
            Description = "УЭ";
            Name = elemnt.product.Name;
            Cost = elemnt.Count * elemnt.PriceOne;
        }

        public AditionalElement(FinishingWork work)
        {
            Description = "ОР";
            Name = work.Name;
            Cost = work.Count * work.Price;
        }

        public AditionalElement(Set set)
        {
            Description = "СП";
            Name = set.Product.Name;
            Cost = set.MinimumPrice;
        }
    }
}
