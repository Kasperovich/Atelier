using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    class FinishingWorkRepository
    {
        public FinishingWork GetById(int workId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.FinishingWorks.Where(f => f.id==workId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<FinishingWork> GetByOrderId(int orderId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.FinishingWorks.Where(f => f.OrderId == orderId).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public string Create(FinishingWork work)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    context.FinishingWorks.Add(work);
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(FinishingWork work)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    context.Entry(work).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int workId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var work = context.FinishingWorks.Where(f => f.id == workId).FirstOrDefault();
                    if (work != null)
                    {
                        context.FinishingWorks.Remove(work);
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
