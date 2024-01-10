using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAppWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public FoodController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("addf")]
        public async Task<IActionResult> AddFood([FromForm] FoodModel foodModel)
        {
            if (_dbContext.Food_Details != null)
            {
                _dbContext.Food_Details.Add(foodModel);
            }
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAllFood()
        {
            if (_dbContext.Food_Details == null)
            {
                return NotFound();
            }
            var foodList = _dbContext.Food_Details.ToList();
            return Ok(foodList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            if (_dbContext.Food_Details == null)
            {
                return NotFound();
            }
            var food = await _dbContext.Food_Details.FirstOrDefaultAsync(f => f.id == id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(int id, [FromBody] FoodModel foodModel)
        {
            if (id != foodModel.id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Entry(foodModel).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPut("update-offer/{id}")]
        public async Task<IActionResult> UpdateOfferZone(int id, [FromBody] FoodModel foodModel)
        {
            if (id != foodModel.id)
            {
                return BadRequest();
            }
            if (_dbContext.Food_Details == null)
            {
                return NotFound();
            }
            var existingFood = await _dbContext.Food_Details.FindAsync(id);
            if (existingFood == null)
            {
                return NotFound();
            }
            existingFood.offerStartTime = foodModel.offerStartTime;
            existingFood.offerEndTime = foodModel.offerEndTime;
            existingFood.offerPercentage = foodModel.offerPercentage;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            if (_dbContext.Food_Details == null)
            {
                return NotFound();
            }
            var food = await _dbContext.Food_Details.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            _dbContext.Food_Details.Remove(food);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        private bool FoodExists(int id)
        {
            return _dbContext.Food_Details?.Any(f => f.id == id) ?? false;
        }
    }
}
