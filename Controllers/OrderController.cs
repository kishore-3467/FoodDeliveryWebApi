using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAppWA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> PostOrderItems([FromBody] OrderModel[] orderItems)
        {
            
            foreach (var orderItem in orderItems)
            {
                _dbContext.Order_Details?.Add(orderItem);
            }

            await _dbContext.SaveChangesAsync();

            return Ok(); 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersByDeliveryId(int id)
        {
            if (_dbContext.Order_Details == null)
            {
                return NotFound();
            }
            var orders = await _dbContext.Order_Details.Where(f => f.deliveryId == id).ToListAsync();
            if (orders == null || orders.Count == 0)
            {
                return NotFound();
            }
            return Ok(orders);
        }
    }
}
