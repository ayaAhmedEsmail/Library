namespace Library.Models.Books
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetById(int id);
        Book Add(Book book);
        Book Update(int id, Book book);
        bool Delete(int id);
        List<Book> GetBooksByAuthor(string author);
        List<int> getShelfGenra(string genre);
        List<Book> GetBooksByPriceRange(double minPrice, double maxPrice);
        List<Book> GetBooksByGenre(string genre);
        List<Book> GetBooksByShelf(int shelf);


        
    }
}
