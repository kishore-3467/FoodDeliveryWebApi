using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAppWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("addu")]
        public async Task<IActionResult> AddUser([FromForm] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { errors = errors.ToList() });
            }
            if(_dbContext.User_Details!=null){
            _dbContext.User_Details.Add(userModel);}
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        
        
        [HttpPost("login")]
        public IActionResult Login(UserModel userModel)
        {
            var user = _dbContext.User_Details?.FirstOrDefault(u => u.userEmail == userModel.userEmail && u.userPassword == userModel.userPassword);
            if (user == null)
            {
                return NotFound("Invalid email or password.");
            }
            
            var userRole = user.userRole; 
            Request.Headers.Add("UserlocalId", user.userId.ToString());
            return Ok(new { userId = user.userId, userRole }); 
        }
        [HttpGet("profile")]
        public IActionResult GetProfile(int userId)
        {
            var user = _dbContext.User_Details?.FirstOrDefault(u => u.userId == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }
        [HttpPut("profileu/{userId}")]
        public IActionResult UpdateProfile(int userId, [FromBody] UserModel userModel)
        {
            var user = _dbContext.User_Details?.FirstOrDefault(u => u.userId == userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            user.userName = userModel.userName;
            user.userNumber = userModel.userNumber;
            user.userAddress1 = userModel.userAddress1;
            user.userEmail = userModel.userEmail;
            user.userDOB = userModel.userDOB;
            user.userPassword = userModel.userPassword;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
