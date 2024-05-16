using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    public static class FinishingWorkService
    {
        public static List<AditionalElement> GetFinishingWorkPrintByOrderId(int orderId)
        {
            List<AditionalElement> fwPrint = new List<AditionalElement>();
            var fWorks = GetByOrderId(orderId);
            foreach (FinishingWork fWork in fWorks)
            {
                fwPrint.Add(new AditionalElement(fWork));
            }
            return fwPrint;
        }
        public static decimal coutingFinishingWorkPrice(int orderId)
        {
            FinishingWorkRepository workRepo = new FinishingWorkRepository();
            var finishingWorks = workRepo.GetByOrderId(orderId);
            if (finishingWorks != null)
            {
                decimal summ = 0;
                foreach(FinishingWork finishingWork in finishingWorks)
                {
                    summ += finishingWork.Count * finishingWork.Price;
                }
                return summ;
            }
            return 0;
        }
        public static FinishingWork GetById(int workId)
        {
            FinishingWorkRepository workRepo = new FinishingWorkRepository();
            return workRepo.GetById(workId);
        }

        public static List<FinishingWork> GetByOrderId(int orderId)
        {
            FinishingWorkRepository workRepo = new FinishingWorkRepository();
            return workRepo.GetByOrderId(orderId);
        }
        public static string Delete(int workId)
        {
            FinishingWorkRepository workRepo = new FinishingWorkRepository();
            return workRepo.Delete(workId);
        }

        public static string Update(FinishingWork work)
        {
            FinishingWorkRepository workRepo = new FinishingWorkRepository();
            return workRepo.Update(work);
        }
        public static string Create(FinishingWork work)
        {
            FinishingWorkRepository workRepo = new FinishingWorkRepository();
            return workRepo.Create(work);
        }
    }
}
