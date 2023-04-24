using APICrud.Models;
using Microsoft.AspNetCore.Mvc;
using APICrud.Service;

namespace APICrud.Controllers
{
    [ApiController]
    [Route("api/customers/{customerId}/orders/{orderId}/shipments")]
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService ?? throw new ArgumentNullException(nameof(shipmentService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shipment>> GetAllShipments()
        {
            var shipments = _shipmentService.GetAllShipments();
            return Ok(shipments);
        }

        [HttpPost]
        public ActionResult<Shipment> CreateShipment(Shipment shipment)
        {
            _shipmentService.CreateShipment(shipment);
            return CreatedAtRoute(
                "GetShipment",
                new { shipmentId = shipment.ShipmentId },
                shipment);
        }

        [HttpGet("{shipmentId}", Name = "GetShipment")]
        public ActionResult<Shipment> GetShipmentById(int shipmentId)
        {
            var shipment = _shipmentService.GetShipmentById(shipmentId);
            if (shipment == null)
            {
                return NotFound();
            }

            return Ok(shipment);
        }

        [HttpPut("{shipmentId}")]
        public IActionResult UpdateShipment(int customerId, int orderId, int shipmentId, Shipment shipment)
        {
            var existingShipment = _shipmentService.GetShipmentById(shipmentId);
            if (existingShipment == null)
            {
                return NotFound();
            }

            _shipmentService.UpdateShipment(existingShipment);

            return NoContent();
        }

        [HttpDelete("{shipmentId}")]
        public IActionResult DeleteShipment(int customerId, int orderId, int shipmentId, Shipment shipment)
        {
            var existingShipment = _shipmentService.GetShipmentById(shipmentId);
            if (existingShipment == null)
            {
                return NotFound();
            }

            _shipmentService.DeleteShipment(existingShipment);

            return NoContent();
        }
    }
}
