using System.Collections.Generic;
using APICrud.Models;
using APICrud.Repositories;
using APICrud.UnitofWork;

namespace APICrud.Service
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IEnumerable<Order> GetCustomerOrders(int customerId);
        IEnumerable<Shipment> GetOrderShipments(int customerId, int orderId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.Customers.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _unitOfWork.Customers.GetCustomerById(id);
        }

        public void CreateCustomer(Customer customer)
        {
            _unitOfWork.Customers.CreateCustomer(customer);
            _unitOfWork.SaveAsync();
        }

        public void UpdateCustomer(Customer customer)
        {
            _unitOfWork.Customers.UpdateCustomer(customer);
            _unitOfWork.SaveAsync();
        }

        public void DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.DeleteCustomer(customer);
            _unitOfWork.SaveAsync();
        }

        public IEnumerable<Order> GetCustomerOrders(int customerId)
        {
            return _unitOfWork.Customers.GetCustomerOrders(customerId);
        }

        public IEnumerable<Shipment> GetOrderShipments(int customerId, int orderId)
        {
            return _unitOfWork.Customers.GetOrderShipments(customerId, orderId);
        }
    }
}
