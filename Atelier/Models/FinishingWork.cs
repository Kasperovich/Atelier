using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class FinishingWork
    {
        public int id { get; set; }
        public string Name { get; set; }
        //Еденица измерения
        public string Unit { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}
