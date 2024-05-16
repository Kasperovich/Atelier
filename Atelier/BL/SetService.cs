using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    static public class SetService
    {
        static public List<AditionalElement> GetSetsPrintByOrderId(int orderId)
        {
            List<AditionalElement> setPrint = new List<AditionalElement>();
            var sets = getSetsByOrderId(orderId);
            foreach (Set set in sets)
            {
                setPrint.Add(new AditionalElement(set));
            }
            return setPrint;
        }
        static public decimal coutingMinPrice(int orderId)
        {
            decimal summ = 0;
            var sets = getSetsByOrderId(orderId);
            foreach (Set set in sets)
            {
                summ += set.MinimumPrice;
            }
            return summ;
        }
        static public string Delete(int setId)
        {
            SetRepository setRepo = new SetRepository();
            return setRepo.Delete(setId);
        }
        static public string Update(Set set)
        {
            SetRepository setRepo = new SetRepository();
            return setRepo.Update(set);
        }
        static public string Create(Set set)
        {
            SetRepository setRepo = new SetRepository();
            return setRepo.Create(set);
        }
        static public List<Set> getSetsByOrderId(int orderId)
        {
            SetRepository setRepo = new SetRepository();
            return setRepo.getSetsByOrderId(orderId);
        }
        static public Set getSetsById(int setId)
        {
            SetRepository setRepo = new SetRepository();
            return setRepo.getSetsById(setId);
        }
    }
}
