using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    class ListOfMaterialRepository
    {
        public List<ListOfMaterial> GetAll()
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.ListOfMaterials.Include(l=> l.Material).Include(l=> l.order).Include(l=> l.order.Worker).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public List<ListOfMaterial> getMaterialsByOrderId(int orderId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.ListOfMaterials.Include(l => l.Material).Where(l => l.OrderId == orderId).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public ListOfMaterial GetById(int listId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.ListOfMaterials.Where(l => l.Id == listId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ListOfMaterial> GetByOrderId(int orderId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.ListOfMaterials.Include(l => l.order).Include(l => l.Material).Where(l => l.OrderId == orderId).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public string Create(ListOfMaterial list)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    context.ListOfMaterials.Add(list);
                    context.SaveChanges();
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(ListOfMaterial list)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    context.Entry(list).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int listId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var list = context.ListOfMaterials.Where(l => l.Id == listId).FirstOrDefault();
                    if (list != null)
                    {
                        context.ListOfMaterials.Remove(list);
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
