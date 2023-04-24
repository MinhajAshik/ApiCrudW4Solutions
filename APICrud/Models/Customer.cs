using System.ComponentModel.DataAnnotations;

namespace APICrud.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
    }
}
