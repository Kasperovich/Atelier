using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    public class MaterialRepository
    {
        public Material getById(int materialId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Materials.Where(m => m.MaterialId == materialId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public Material getByCode(int materialCode)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Materials.Where(m => m.Code == materialCode).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public string Delete(int materialId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var listOfMaterial = context.ListOfMaterials.Where(l => l.MaterialId == materialId).FirstOrDefault();
                    if (listOfMaterial != null) return "Невозможно удалить, материал используется в заказе";
                    var material = context.Materials.Where(m => m.MaterialId == materialId).FirstOrDefault();
                    if (material != null)
                    {
                        context.Materials.Remove(material);
                        context.SaveChanges();
                    }
                    return null;
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Create(Material material)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var mat = context.Materials.Where(m => m.Name == material.Name||m.Code == material.Code).FirstOrDefault();
                    if (mat != null) return "Материал с таким именем или кодом уже внесен";
                    context.Materials.Add(material);
                    context.SaveChanges();
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(Material material)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var mat = getById(material.MaterialId);
                    if (material.Code == mat.Code)
                    {
                        context.Entry(material).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        if (getByCode(material.Code) == null)
                        {
                            context.Entry(material).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            return "Материал с таким кодом уже внесен";
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
