using APICrud.Models;
using APICrud.UnitofWork;

namespace APICrud.Service
{
    public interface IShipmentService
    {
        IEnumerable<Shipment> GetAllShipments();
        Shipment GetShipmentById(int id);
        void CreateShipment(Shipment shipment);
        void UpdateShipment(Shipment shipment);
        void DeleteShipment(Shipment shipment);
    }
    public class ShipmentService : IShipmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Shipment> GetAllShipments()
        {
            return _unitOfWork.Shipments.GetAllShipments();
        }

        public Shipment GetShipmentById(int id)
        {
            return _unitOfWork.Shipments.GetShipmentById(id);
        }

        public void CreateShipment(Shipment shipment)
        {
            _unitOfWork.Shipments.CreateShipment(shipment);
            _unitOfWork.SaveAsync();
        }

        public void UpdateShipment(Shipment shipment)
        {
            _unitOfWork.Shipments.UpdateShipment(shipment);
            _unitOfWork.SaveAsync();
        }

        public void DeleteShipment(Shipment shipment)
        {
            _unitOfWork.Shipments.DeleteShipment(shipment);
            _unitOfWork.SaveAsync();
        }

    }
}
