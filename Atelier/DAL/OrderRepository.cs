using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.DAL
{
    public class OrderRepository
    {

        public Order GetById(int orderId)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    return context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }
        public Order GetOrderByReceiptNumber(string receiptNumber)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Orders.Where(o => o.ReceiptNumber == receiptNumber).Include(o => o.Worker).FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public string Update(Order order)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    context.Entry(order).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string deleteOrder(int orderId)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var order = context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
                    if (order != null)
                    {
                        context.Orders.Remove(order);
                        context.SaveChanges();
                        return null;
                    }
                    else
                    {
                        return "Запись не существует";
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Order> GetAllOrders()
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Orders.Include(o => o.Worker).Include(o => o.ListOfMaterials.Select(l=>l.Material)).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Order> GetOrdertsByFormOfPayment(bool formOfPayment)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    return context.Orders.Where(o=>o.FormOfPayment == formOfPayment)
                                         .Include(o => o.Worker)
                                         .Include(o => o.ListOfMaterials.Select(l => l.Material))
                                         .ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public string Create(Order order)
        {
            try
            {
                using(AtelierContext context = new AtelierContext())
                {
                    var or = context.Orders.Where(o => o.ReceiptNumber == order.ReceiptNumber).FirstOrDefault();
                    if (or != null) return "Заказ с таким номером квитанции уже внесен";
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int orderId)
        {
            try
            {
                using (AtelierContext context = new AtelierContext())
                {
                    var order = context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
                    context.Orders.Remove(order);
                    context.SaveChanges();
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
