using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }
        public string Unit { get; set; }
        public string StringType { get; set; }

        public List<ListOfMaterial> ListOfMaterials { get; set; }
        public Material()
        {
            ListOfMaterials = new List<ListOfMaterial>();
        }

        public Material(int code, string name, bool type, string unit)
        {
            Code = code;
            Name = name;
            Unit = unit;
            Type = type;
            StringType = type ? "Основной" : "Прикладной";
        }

        public Material(int id,int code, string name, bool type, string unit)
        {
            MaterialId = id;
            Code = code;
            Unit = unit;
            Name = name;
            Type = type;
            StringType = type ? "Основной" : "Прикладной";
        }
    }
}
