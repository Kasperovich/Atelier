﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class Set
    {
        public int Id { get; set; }
        public decimal MinimumPrice { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
