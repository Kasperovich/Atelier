using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    public static class ComplicatingElementService
    {
        public static List<AditionalElement> GetElementPrintByOrderId(int orderId)
        {
            List<AditionalElement> elementPrint = new List<AditionalElement>();
            var element = GetByOrderId(orderId);
            foreach (ComplicatingElement elem in element)
            {
                elementPrint.Add(new AditionalElement(elem));
            }
            return elementPrint;
        }
        public static decimal coutingComplicatingElements(int orderId)
        {
            decimal summ = 0;
            ComplicatingElementRepository elementRepo = new ComplicatingElementRepository();
            var elements = elementRepo.GetByOrderId(orderId);
            foreach (ComplicatingElement element in elements)
            {
                summ += element.PriceOne * element.Count;
            }
            return summ;
        }

        public static ComplicatingElement GetById(int elementId)
        {
            ComplicatingElementRepository elementRepo = new ComplicatingElementRepository();
            return elementRepo.GetById(elementId);
        }

        public static List<ComplicatingElement> GetByOrderId(int orderId)
        {
            ComplicatingElementRepository elementRepo = new ComplicatingElementRepository();
            return elementRepo.GetByOrderId(orderId);
        }

        public static string Create(ComplicatingElement element)
        {
            ComplicatingElementRepository elementRepo = new ComplicatingElementRepository();
            return elementRepo.Create(element);
        }

        public static string Update(ComplicatingElement element)
        {
            ComplicatingElementRepository elementRepo = new ComplicatingElementRepository();
            return elementRepo.Update(element);
        }

        public static string Delete(int elementId)
        {
            ComplicatingElementRepository elementRepo = new ComplicatingElementRepository();
            return elementRepo.Delete(elementId);
        }
    }
}
