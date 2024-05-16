using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    public class ProductRepository
    {
        public Product GetByCode(int code)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Products.Where(p => p.Code == code).FirstOrDefault();
                }
            }
            catch 
            {
                return null;
            }
        }
        public string Create(Product product)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var pr = context.Products.Where(p => p.Name == product.Name).FirstOrDefault();
                    if (pr != null) return "Запись с таким изделием уже существует";
                    pr = context.Products.Where(p => p.Code == product.Code).FirstOrDefault();
                    if (pr != null) return "Запись с таким кодом уже существует";
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int productid)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var set = context.Sets.Where(s => s.ProductId == productid).FirstOrDefault();
                    if (set != null) return "Невозможно удалить, изделие уже используется в заказе";
                    var product = context.Products.Where(p => p.ProductId == productid).FirstOrDefault();
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(Product product)
        {
            try
            {
                if (product != null)
                {
                    using (AtelierContext context = new AtelierContext())
                    {
                        var prodCode = GetByCode(product.Code);
                        if (prodCode == null)
                        {
                            context.Entry(product).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            if(prodCode.ProductId == product.ProductId)
                            {
                                context.Entry(product).State = EntityState.Modified;
                                context.SaveChanges();
                            }
                            else
                            {
                                return "Изделие с таким кодом уже внесено";
                            }
                        }

                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
