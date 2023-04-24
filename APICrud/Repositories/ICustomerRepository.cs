using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using APICrud.Models;
using APICrud.Repositories;



namespace APICrud.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IEnumerable<Order> GetCustomerOrders(int customerId);
        IEnumerable<Shipment> GetOrderShipments(int customerId, int orderId);
    }
}
