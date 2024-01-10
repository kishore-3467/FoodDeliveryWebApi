using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAppWA.Models;
using FoodDeliveryAppWA.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAppWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("addbook")]
        public async Task<IActionResult> AddBook([FromForm] BookModel bookModel)
        {
            if (_dbContext.Book_Details != null)
            {
                _dbContext.Book_Details.Add(bookModel);
            }
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("allbooks")]
        public IActionResult GetAllBook()
        {
            if (_dbContext.Book_Details == null)
            {
                return NotFound();
            }
            var bookList = _dbContext.Book_Details.ToList();
            return Ok(bookList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            if (_dbContext.Book_Details == null)
            {
                return NotFound();
            }
            var book = await _dbContext.Book_Details.FirstOrDefaultAsync(f => f.bookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel bookModel)
        {
            if (id != bookModel.bookId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Entry(bookModel).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_dbContext.Book_Details == null)
            {
                return NotFound();
            }
            var book = await _dbContext.Book_Details.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _dbContext.Book_Details.Remove(book);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        private bool BookExists(int id)
        {
            return _dbContext.Book_Details?.Any(f => f.bookId == id) ?? false;
        }
    }
}
