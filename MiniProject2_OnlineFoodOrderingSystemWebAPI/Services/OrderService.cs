using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> _orderList = new List<Order>();

        public void PlaceOrder(Order order)
        {
            order.OrderId = _orderList.Count + 1;
            order.OrderDate = DateTime.Now;
            order.TotalPrice = order.CalculateTotalOrder();
            _orderList.Add(order);
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _orderList;
        }
        public Order DisplayOrderDetail(int orderId)
        {
            return _orderList.Find(cek => cek.OrderId == orderId);
        }
        public string GetOrderStatus(int orderId)
        {
            var orderDetail = _orderList.Find(cek=>cek.OrderId == orderId);
            if (orderDetail == null)
            {
                return $"Order dengan order ID {orderId} tidak ada.";
            }
            return $"Order Status : {orderDetail.Status}";
        }
        public bool UpdateOrderStatus(int orderId, string status)
        {
            var existingOrder = _orderList.Find(cek=>cek.OrderId == orderId);
            if (existingOrder == null)
            {
                return false;
            }
            existingOrder.Status = status;
            return true;
        }
        public bool CancelOrder(int orderId)
        {
            var cancelOrder = _orderList.Find(cek => cek.OrderId == orderId);
            if (cancelOrder == null)
            {
                return false;
            }
            cancelOrder.Status = "Cancelled";
            return true;
        }
    }

}
