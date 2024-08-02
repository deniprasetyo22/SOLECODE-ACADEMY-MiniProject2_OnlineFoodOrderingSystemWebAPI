using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        Order DisplayOrderDetail(int orderId);
        IEnumerable<Order> GetAllOrder();
        string GetOrderStatus(int orderId);
        bool UpdateOrderStatus(int orderId, string status);
        bool CancelOrder(int orderId);
    }

}
