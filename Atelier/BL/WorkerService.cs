using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    public static class WorkerService
    {

        public static List<Worker> GetWorkerByOpenOrders(bool formOfPayment)
        {
            WorkerRepository workerRepo = new WorkerRepository();
            return workerRepo.GetAll().Where(w => w.Orders
                                                   .Where(o => o.FormOfPayment == formOfPayment && o.isClosed == false)
                                                   .Count() > 0)
                                                   .ToList();
        }
        public static string Create(Worker worker)
        {
            WorkerRepository workerRepo = new WorkerRepository();
            return workerRepo.Create(worker);
        }

        public static string Update(Worker worker)
        {
            WorkerRepository workerRepo = new WorkerRepository();
            return workerRepo.Update(worker);
        }

        public static Worker GetById(int workerId)
        {
            WorkerRepository workerRepo = new WorkerRepository();
            return workerRepo.GetById(workerId);
        }

        public static string Delete(int workerId)
        {
            WorkerRepository workerRepo = new WorkerRepository();
            return workerRepo.Delete(workerId);
        }
    }
}
