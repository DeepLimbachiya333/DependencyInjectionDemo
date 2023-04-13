using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            this._bookService=bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var allbooks = await _bookService.GetBooks();

            if(allbooks == null)
            {
                return NotFound();
            }
            return Ok(allbooks);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (!_bookService.BookExists(id))
            {
                return BadRequest();
            }
            var book = await _bookService.GetBook(id);
            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if(id != book.BookId)
            {
                return BadRequest();
            }
            try
            {
                await _bookService.UpdateBook(book);
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!_bookService.BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBook(Book book)
        {
           await _bookService.AddBook(book);
            return Ok();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (!_bookService.BookExists(id))
            {
                return BadRequest();
            }
            await _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
