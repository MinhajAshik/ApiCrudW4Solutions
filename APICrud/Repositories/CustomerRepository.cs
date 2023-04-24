using APICrud.Models;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Repositories
{

    public class CustomerRepository : RepositoryBases<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _dbContext;


        public CustomerRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return GetById(id);
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        public IEnumerable<Order> GetCustomerOrders(int customerId)
        {
            return Context.Set<Order>().Where(o => o.CustomerId == customerId).ToList();
        }

        public IEnumerable<Shipment> GetOrderShipments(int customerId, int orderId)
        {
            return Context.Set<Shipment>().Where(s => s.OrderId == orderId && s.Order.CustomerId == customerId).ToList();
        }

    }

}
