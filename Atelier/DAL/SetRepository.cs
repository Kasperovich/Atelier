using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Atelier.Models;

namespace Atelier.DAL
{
    class SetRepository
    {
        public Set getSetsById(int setId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Sets.Include(s => s.Product).Include(s => s.Order).Where(s => s.Id == setId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }
        public string Delete(int setId)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var set = context.Sets.Where(s => s.Id == setId).FirstOrDefault();
                    if(set!= null)
                    {
                        context.Sets.Remove(set);
                        context.SaveChanges();
                        return null;
                    }
                    else
                    {
                        return "Запись не существует";
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Update(Set set)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    context.Entry(set).State = EntityState.Modified;
                    context.SaveChanges();

                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Create(Set set)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    context.Sets.Add(set);
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Set> getSetsByOrderId(int orderId)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    return context.Sets.Include(s=>s.Product).Where(s => s.OrderId == orderId).ToList();
                }
            }
            catch
            {
                return null; 
            }
        }
    }
}
