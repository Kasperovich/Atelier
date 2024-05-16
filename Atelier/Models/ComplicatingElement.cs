using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class ComplicatingElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal PriceOne { get; set; }
        public int? ProductId { get; set; }
        public Product product { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}
