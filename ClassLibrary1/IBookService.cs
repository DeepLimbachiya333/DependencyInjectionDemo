namespace ClassLibrary1
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task DeleteBook(int Id);
        Task<IEnumerable<Book>> GetBooks();
        Task<Book?> GetBook(int Id);
        Task UpdateBook(Book book);
        public bool BookExists(int id);
    }
}