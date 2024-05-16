using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier
{
    class Print
    {
        Order order;
        List<ComplicatingElement> complicatingElements;
        List<FinishingWork> finishingWork;
        List<ListOfMaterial> listOfMaterial;
        List<Set> set;

        public Print (Order _order, List<ComplicatingElement> _complicatingElements, List<FinishingWork> _finishingWork, List<ListOfMaterial> _listOfMaterial, List<Set> _set)
        {
            order = _order;
            complicatingElements = _complicatingElements;
            finishingWork = _finishingWork;
            listOfMaterial = _listOfMaterial;
            set = _set;
        }


    }
}
