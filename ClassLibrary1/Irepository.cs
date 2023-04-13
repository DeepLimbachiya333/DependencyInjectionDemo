using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IRepository
    {
        Task AddBook(Book book);
        Task DeleteBook(int Id);
        Task<IEnumerable<Book>> GetBooks();
        Task<Book?> GetBook(int Id);
        Task UpdateBook(Book book);
        public bool BookExists(int id);
    }
}
