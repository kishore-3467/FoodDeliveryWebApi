using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAppWA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public DeliveryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateDelivery(DeliveryModel deliveryModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { errors = errors.ToList() });
            }
            var user_table = _dbContext.User_Details?.FirstOrDefault(u => u.userRole == "Delivery" && u.userAvailability == false);
            if (user_table == null)
            {
                return NotFound("No available delivery man found.");
            }
            deliveryModel.deliveryManId = user_table.userId;
            deliveryModel.deliveryStatus = false;
            _dbContext.Delivery_Details?.Add(deliveryModel);
            await _dbContext.SaveChangesAsync();
            // Update user availability, deliveryId, and customerId
            user_table.userAvailability = true;
            user_table.deliveryId = deliveryModel.id;
            _dbContext.SaveChanges();
            // Set deliveryModel.id and deliveryModel.deliveryManId before returning
            deliveryModel.id = deliveryModel.id;
            deliveryModel.deliveryManId = user_table.userId;
            // Return deliveryModel.id and deliveryModel.deliveryManId
            return Ok(deliveryModel);
        }
        [HttpGet("getDeliveryByUserId/{userId}")]
        public async Task<IActionResult> GetDeliveryByUserId(int userId)
        {
            if (_dbContext.Delivery_Details == null)
            {
                return NotFound();
            }
            var deliveries = await _dbContext.Delivery_Details.Where(d => d.userId == userId).ToListAsync();
            return Ok(deliveries);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryById(int id)
        {
            if (_dbContext.Delivery_Details == null)
            {
                return NotFound();
            }
            var delivery = await _dbContext.Delivery_Details.FirstOrDefaultAsync(f => f.id == id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }
        [HttpGet("AllD")]
        public async Task<IActionResult> GetAllDelivery()
        {
            if (_dbContext.Delivery_Details == null)
            {
                return NotFound();
            }
            var delivery = await _dbContext.Delivery_Details.ToListAsync();
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }
        [HttpPut("postQuery/{id}/{userRole}")]
        public async Task<IActionResult> PostQuery(int id,string userRole,[FromBody] DeliveryModel deliveryModel)
        {
            if (_dbContext.Delivery_Details == null)
            {
                return NotFound();
            }
            var delivery = await _dbContext.Delivery_Details.FindAsync(deliveryModel.id);
            if (delivery == null)
            {
                return NotFound();
            }
            if (userRole=="Admin")//this method to check if the user is an admin.
            {
                if (!string.IsNullOrEmpty(deliveryModel.orderQueriesOut))
                {
                    if (!string.IsNullOrEmpty(delivery.orderQueriesOut))
                    {
                        delivery.orderQueriesOut += "\n";
                    }
                    delivery.orderQueriesOut += deliveryModel.orderQueriesOut;
                }
            }
            else if (userRole=="User") //this method to check if the user is a regular user.
            {
                if (!string.IsNullOrEmpty(deliveryModel.orderQueriesIn))
                {
                    if (!string.IsNullOrEmpty(delivery.orderQueriesIn))
                    {
                        delivery.orderQueriesIn += "\n";
                    }
                    delivery.orderQueriesIn += deliveryModel.orderQueriesIn;
                }
            }
            else
            {
                return BadRequest("Invalid user role.");
            }
            await _dbContext.SaveChangesAsync();
            return Ok("Query posted successfully!");
        }

        [HttpPut("delivery")]
        public async Task<IActionResult> OrderDelivered([FromBody] DeliveryModel deliveryModel)
        {
            var deliveryDetails = await _dbContext.Delivery_Details.FirstOrDefaultAsync(d => d.id == deliveryModel.id);
            if (deliveryDetails == null)
            {
                return NotFound();
            }
            var deliveryMan = await _dbContext.User_Details.FirstOrDefaultAsync(u => u.userId == deliveryModel.deliveryManId);
            if (deliveryMan != null)
            {
                deliveryMan.userAvailability = false;
                deliveryMan.customerId = 0;
                deliveryMan.deliveryId = 0;
            }

            deliveryDetails.deliveryStatus = true;
            await _dbContext.SaveChangesAsync();
            return Ok("Food Delivered successfully!");
        }

    }
}
