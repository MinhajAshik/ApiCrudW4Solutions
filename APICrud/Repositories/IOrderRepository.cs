using APICrud.Models;

namespace APICrud.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        IEnumerable<Shipment> GetOrderShipments(int orderId);
    }
}
