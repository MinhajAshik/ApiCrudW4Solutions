using System.ComponentModel.DataAnnotations;

namespace APICrud.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
