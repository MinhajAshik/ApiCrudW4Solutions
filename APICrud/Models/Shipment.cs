using System.ComponentModel.DataAnnotations;

namespace APICrud.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShipmentDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
