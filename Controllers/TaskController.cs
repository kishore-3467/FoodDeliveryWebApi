using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace FoodDeliveryAppWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployee([FromForm] TaskEmployeeModel taskEmployeeModel)
        {
            taskEmployeeModel.employeeId=0;
            if(_dbContext.TaskTable_Details!=null){
            _dbContext.TaskTable_Details.Add(taskEmployeeModel);}
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("allemployee")]
        public IActionResult GetAllEmployee()
        {
            if (_dbContext.TaskTable_Details == null)
            {
                return NotFound();
            }
            var foodList = _dbContext.TaskTable_Details.ToList();
            return Ok(foodList);
        }
    }
}