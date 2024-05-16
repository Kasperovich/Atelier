using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    class ComplicatingElementRepository
    {
        public ComplicatingElement GetById(int elementId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.ComplicatingElements.Where(c => c.Id == elementId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ComplicatingElement> GetByOrderId(int orderId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.ComplicatingElements.Include(c => c.order).Include(c => c.product).Where(c => c.OrderId == orderId).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public string Create(ComplicatingElement element)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    context.ComplicatingElements.Add(element);
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(ComplicatingElement element)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    context.Entry(element).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int elementId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var elememt = context.ComplicatingElements.Where(c => c.Id == elementId).FirstOrDefault();
                    if (elememt != null)
                    {
                        context.ComplicatingElements.Remove(elememt);
                        context.SaveChanges();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
