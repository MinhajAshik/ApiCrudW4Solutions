using APICrud.Models;
using APICrud.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICrud.Controllers
{
    
    [ApiController]
    
    [Route("api/customers/{customerId}/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();

            return Ok(orders);
        }

        [HttpGet("{orderId}", Name = "GetOrder")]
        public ActionResult<Order> GetOrderById(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);

            return CreatedAtRoute("GetOrder", new { orderId = order.OrderId }, order);
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder(int orderId, Order order)
        {
            if (orderId != order.OrderId)
            {
                return BadRequest("The Order ID in the URL does not match the Order ID in the request body");
            }

            _orderService.UpdateOrder(order);

            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(int orderId, Order order)
        {
            _orderService.DeleteOrder(order);

            return NoContent();
        }
    }
}
