using APICrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace APICrud.Repositories
{
    public class OrderRepository : RepositoryBases<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return GetAll();
        }

        public Order GetOrderById(int id)
        {
            return GetById(id);
        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public IEnumerable<Shipment> GetOrderShipments(int orderId)
        {
            return Context.Set<Shipment>().Where(s => s.OrderId == orderId).ToList();
        }
    }
}
