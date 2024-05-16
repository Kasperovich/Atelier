using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models.ModelsForReports
{
    public class WorkerForReport
    {
        public int WorkerId { get; set; }
        public int Code { get; set; }
        public string FIO { get; set; }
        public bool FormOfPayment { get; set; }

        public WorkerForReport(Worker worker, bool _formOfPayment)
        {
            WorkerId = worker.WorkerId;
            Code = worker.Code;
            FIO = worker.FIO;
            FormOfPayment = _formOfPayment;
        }
    }
}
