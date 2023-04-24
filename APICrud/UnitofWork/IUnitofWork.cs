using APICrud.Repositories;

namespace APICrud.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IShipmentRepository Shipments { get; }
        Task<int> SaveAsync();
    }
}
