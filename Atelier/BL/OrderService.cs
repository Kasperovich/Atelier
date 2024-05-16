using Atelier.DAL;
using Atelier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.BL
{
    static public class OrderService
    {
        public static  decimal GetCostOfSewingByOrderId(int orderId)
        {
            decimal sum;

            var order = getOrderById(orderId);
            var complicatingElements = ComplicatingElementService.coutingComplicatingElements(orderId);
            var minPrice = SetService.coutingMinPrice(orderId);
            var finishingWork = Convert.ToDecimal(FinishingWorkService.coutingFinishingWorkPrice(orderId));

            return sum = Math.Round(((minPrice + complicatingElements + finishingWork) * 
                          (decimal)order.Coefficient) * 
                          order.CountProduct,2);
        }

        public static List<Order> GetOrderByWorkerIdAndFormOfPayment(int workerId, bool formOfPayment)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetAllOrders().Where(o => o.Workerid == workerId && 
                                                  o.FormOfPayment == formOfPayment &&
                                                  o.isClosed == false)
                                           .OrderBy(o => o.DateOfReceipt)
                                           .ToList();
        }
        public static int GetProductCountByOrderId(int orderId)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetById(orderId).CountProduct;
        }
        public static List<Order> GetOrdersForPeriod(DateTime firstDate, DateTime lastDate)
        {
            OrderRepository orderRepo = new OrderRepository();
            var allOrders =orderRepo.GetAllOrders();
            return allOrders.Where(o => o.DateOfReceipt >= firstDate && o.DateOfReceipt <=lastDate ).OrderBy(o=>o.DateOfReceipt).ToList();
        }
        public static List<Order> GetAllOrders()
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetAllOrders();
        }
        public static string GetReceiptNumberByOrderId(int orderId)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetById(orderId).ReceiptNumber;
        }

        public static  Order getOrderById(int orderId)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetById(orderId);
        }
        public static string deleteOrder(int orderId)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.Delete(orderId);
        }
        public static List<Order> GetOrdersByFormOfPayment(bool formOfPayment)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetOrdertsByFormOfPayment(formOfPayment);
        }

        public static Order GetOrdersByReceiptNumber(string receiptNumber)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetOrderByReceiptNumber(receiptNumber);
        }
        public static List<Order> GetOrdersByFormOfPaymentAndReceiptNumber(bool formOfPayment, string receiptNumber)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.GetOrdertsByFormOfPayment(formOfPayment)
                            .Where(o=>o.ReceiptNumber
                            .Contains(receiptNumber))
                            .ToList();
        }

        public static string Create(Order order)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.Create(order);
        }

        public static string Update(Order order)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.Update(order);
        }

        public static string Delete(int orderId)
        {
            OrderRepository orderRepo = new OrderRepository();
            return orderRepo.Delete(orderId);
        }

        public static string DeleteAllIsClosed()
        {
            try
            {
                var orders = GetAllOrders().Where(o => o.isClosed == true);
                if(orders.Count() == 0)
                {
                    return "Закрытые заказы отстутствуют";
                }

                foreach(Order order in orders)
                {
                    Delete(order.OrderId);
                }
                return null;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
