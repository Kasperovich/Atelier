using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class MaterialForReport
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public decimal Price { get; set; }
        public bool Type { get; set; }
    }
}
