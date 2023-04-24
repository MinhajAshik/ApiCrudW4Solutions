using APICrud.Models;

namespace APICrud.Repositories
{
    public interface IShipmentRepository
    {
        IEnumerable<Shipment> GetAllShipments();
        Shipment GetShipmentById(int id);
        void CreateShipment(Shipment shipment);
        void UpdateShipment(Shipment shipment);
        void DeleteShipment(Shipment shipment);
    }
}
