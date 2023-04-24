using APICrud.Models;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Repositories
{
    public class ShipmentRepository : RepositoryBases<Shipment>, IShipmentRepository
    {
        private readonly AppDbContext _dbContext;
        public ShipmentRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Shipment> GetAllShipments()
        {
            return GetAll();
        }

        public Shipment GetShipmentById(int id)
        {
            return GetById(id);
        }

        public void CreateShipment(Shipment shipment)
        {
            Create(shipment);
        }

        public void UpdateShipment(Shipment shipment)
        {
            Update(shipment);
        }

        public void DeleteShipment(Shipment shipment)
        {
            Delete(shipment);
        }
    }
}
