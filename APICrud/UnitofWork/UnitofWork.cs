using APICrud.Repositories;
using Microsoft.EntityFrameworkCore;
using APICrud.Models;
namespace APICrud.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IShipmentRepository _shipmentRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

        public IShipmentRepository Shipments => _shipmentRepository ??= new ShipmentRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
