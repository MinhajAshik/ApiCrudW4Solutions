using APICrud.Models;
using APICrud.Repositories;
using APICrud.UnitofWork;

namespace APICrud.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        IEnumerable<Shipment> GetOrderShipments(int orderId);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
            _unitOfWork.SaveAsync();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
            _unitOfWork.SaveAsync();
        }

        public void DeleteOrder(Order order)
        {
            _orderRepository.DeleteOrder(order);
            _unitOfWork.SaveAsync();
        }

        public IEnumerable<Shipment> GetOrderShipments(int orderId)
        {
            return _orderRepository.GetOrderShipments(orderId);
        }
    }
}
