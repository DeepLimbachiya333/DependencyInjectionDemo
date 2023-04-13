using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class BookService : IBookService
    {
        //private readonly BookContext _context;
        //public BookService(BookContext context)
        //{
        //    _context = context;
        //}
        //public async Task AddBook(Book book)
        //{
        //    _context.Books.Add(book);
        //    await _context.SaveChangesAsync();
        //    //   return book;
        //}
        //public async Task DeleteBook(int Id)
        //{
        //    var book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
        //    if (book != null)
        //    {
        //        _context.Remove(book);
        //        await _context.SaveChangesAsync();
        //    }
        //}
        //public async Task<Book?> GetBook(int Id)
        //{
        //    // return await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
        //    //var book = _context.Books.FirstOrDefault(x => x.BookId == Id);
        //    return await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
        //}
        //public async Task<IEnumerable<Book>> GetBooks()
        //{
        //    return await _context.Books.ToListAsync();
        //}
        //public async Task UpdateBook(Book book)
        //{
        //    _context.Books.Update(book);
        //    await _context.SaveChangesAsync();
        //}
        //public bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.BookId == id);
        //}

        private readonly IRepository _repository;

        public BookService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBook(Book book)
        {
            await _repository.AddBook(book);   
        }

        public bool BookExists(int id)
        {
            return  _repository.BookExists(id);
        }

        public async Task DeleteBook(int Id)
        {
            await _repository.DeleteBook(Id);
        }

        public async Task<Book?> GetBook(int Id)
        {
           return await _repository.GetBook(Id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _repository.GetBooks();
        }

        public async Task UpdateBook(Book book)
        {
           await _repository.UpdateBook(book);  
        }
    }
}
