using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAppWA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("addc")]
        public async Task<IActionResult> AddToCart([FromBody] CartModel cart)
        {
            try
            {
                if (_dbContext.Cart_Details == null)
                {
                    return NotFound();
                }
                bool cartItemExists = await _dbContext.Cart_Details.AnyAsync(c => c.userId == cart.userId && c.foodId == cart.foodId);
                if (cartItemExists)
                {
                    return Conflict("The cart item already exists for the given user and food.");
                }
                _dbContext.Cart_Details.Add(cart);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(500, "An error occurred while adding the item to the cart.");
            }
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            if (_dbContext.Cart_Details == null)
            {
                return NotFound();
            }
            var cartItems = await _dbContext.Cart_Details.Where(c => c.userId == userId).ToListAsync();
            return Ok(cartItems);
        }
        [HttpDelete("remove/{foodId}/{userId}")]
        public async Task<IActionResult> RemoveFromCart(int foodId, int userId)
        {
            try
            {
                if (_dbContext.Cart_Details == null)
                {
                    return NotFound();
                }
                var cartItem = await _dbContext.Cart_Details.FirstOrDefaultAsync(c => c.userId == userId && c.foodId == foodId);
                if (cartItem == null)
                {
                    return NotFound("The specified cart item was not found.");
                }
                _dbContext.Cart_Details.Remove(cartItem);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(500, "An error occurred while removing the item from the cart.");
            }
        }
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteFromCart(int userId)
        {
            try
            {
                if (_dbContext.Cart_Details == null)
                {
                    return NotFound();
                }
                var cartItems = await _dbContext.Cart_Details.Where(c => c.userId == userId).ToListAsync();
                if (!cartItems.Any())
                {
                    return NotFound("No cart items found for the specified user.");
                }
                _dbContext.Cart_Details.RemoveRange(cartItems);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(500, "An error occurred while removing the items from the cart.");
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartModel cart)
        {
            try
            {
                if (_dbContext.Cart_Details == null)
                {
                    return NotFound();
                }
                var cartItem = await _dbContext.Cart_Details.FirstOrDefaultAsync(c => c.userId == cart.userId && c.foodId == cart.foodId);
                if (cartItem == null)
                {
                    return NotFound("The specified cart item was not found.");
                }
                cartItem.foodQuantity = cart.foodQuantity;
                cartItem.foodPrice = cart.foodPrice;
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return StatusCode(500, "An error occurred while updating the item in the cart.");
            }
        }
    }
}