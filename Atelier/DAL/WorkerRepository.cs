using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    public class WorkerRepository
    {

        public List<Worker> GetAll()
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    return context.Workers.Include(w => w.Orders).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public Worker GetById(int workerId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Workers.Where(w => w.WorkerId == workerId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public Worker GetByCode(int workerCode)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Workers.Where(w => w.Code == workerCode).FirstOrDefault();
                }
            }
            catch 
            {
                return null;
            }
        }
        public string Create(Worker worker)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var work = context.Workers.Where(w => w.FIO == worker.FIO).FirstOrDefault();
                    if (work != null) return "Работник с таким именем уже существует";
                    work = context.Workers.Where(w => w.Code == worker.Code).FirstOrDefault();
                    if (work != null) return "Работник с таким кодом уже существует";
                    context.Workers.Add(worker);
                    context.SaveChanges();
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(Worker worker)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var workerCode = GetByCode(worker.Code);
                    if (workerCode == null)
                    {
                        context.Entry(worker).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        if (workerCode.WorkerId == worker.WorkerId)
                        {
                            context.Entry(worker).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            return "Работник с таким кодом уже внесен";
                        }
                    }
                }
                return null;
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int workerid)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var orders = context.Orders.Where(o => o.Workerid == workerid).FirstOrDefault();
                    if (orders != null) return "Невозможно удалить, работник выполняет заказ";
                    var worker = context.Workers.Where(w => w.WorkerId == workerid).FirstOrDefault();
                    if(worker!= null)
                    {
                        context.Workers.Remove(worker);
                        context.SaveChanges();
                    }
                }
                return null;
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
