using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BookRepository : IRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }

        public async Task DeleteBook(int Id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            if (book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Book?> GetBook(int Id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
