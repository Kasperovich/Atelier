using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    static public class MaterialService
    {
        public static string getNameByCode(int materialCode)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            var material = materialRepo.getByCode(materialCode);
            if(material!= null)
            {
                return material.Name;
            }
            return "";
        }

        public static bool getTypeById(int materialId)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            var material = materialRepo.getById(materialId);
            return material.Type;
        }
        public static string getNameById(int materialId)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            var material = materialRepo.getById(materialId);
            if (material != null)
            {
                return material.Name;
            }
            return "";
        }
        public static Material getByCode(int materialCode)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            return materialRepo.getByCode(materialCode);
        }
        public static string Create(Material material)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            return materialRepo.Create(material);
        }

        public static string Delete(int materialId)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            return materialRepo.Delete(materialId);
        }

        public static string Update(Material material)
        {
            MaterialRepository materialRepo = new MaterialRepository();
            return materialRepo.Update(material);
        }
    }
}
