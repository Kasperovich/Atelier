using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    public static class ProductService
    {

        public static Product getByCode(int productCode)
        {
            ProductRepository productRepo = new ProductRepository();
            var productName = productRepo.GetByCode(productCode);
            if (productName != null)
            {
                return productName;
            }
            return null;
        }
        public static string getNameByCode(int productCode)
        {
            ProductRepository productRepo = new ProductRepository();
            var productName =  productRepo.GetByCode(productCode);
            if (productName != null)
            {
                return productName.Name;
            }
            return "";
        }
        public static string Create(Product product)
        {
            ProductRepository productRepo = new ProductRepository();
            return productRepo.Create(product);
        }

        public static string Update(Product product)
        {
            ProductRepository productRepo = new ProductRepository();
            return productRepo.Update(product);
        }

        public static string Delete(int productid)
        {
            ProductRepository productRepo = new ProductRepository();
            return productRepo.Delete(productid);
        }
    }
}
