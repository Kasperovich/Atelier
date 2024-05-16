using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public List<ComplicatingElement> ComplicatingElements { get; set; }
        public List<Set> Sets { get; set; }
        public Product()
        {
            Sets = new List<Set>();
            ComplicatingElements = new List<ComplicatingElement>();
        }

        public Product(int code,string name)
        {
            Code = code;
            Name = name;
        }

        public Product(int productId, int code, string name)
        {
            ProductId = productId;
            Code = code;
            Name = name;
        }
    }
}
