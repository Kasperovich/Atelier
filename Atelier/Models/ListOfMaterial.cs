using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class ListOfMaterial
    {
        public int Id { get; set; }
        //Количество
        public double Quantity { get; set; }
        public decimal Price { get; set; }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}
