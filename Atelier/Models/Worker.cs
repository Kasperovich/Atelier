
using System.Collections.Generic;

namespace Atelier.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public int Code { get; set; }
        public string FIO { get; set; }
        
        public List<Order> Orders { get; set; }
        public Worker()
        {
            Orders = new List<Order>();
        }

        public Worker(int code,string fIO)
        {
            Code = code;
            FIO = fIO;
        }

        public Worker(int workerId,int code, string fIO)
        {
            WorkerId = workerId;
            Code = code;
            FIO = fIO;
        }
    }
}
