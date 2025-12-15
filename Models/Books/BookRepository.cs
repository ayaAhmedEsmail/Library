namespace Library.Models.Books
{

    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = [

             new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 15.99,
                      Barcode = "9780743273565", ShelfId = 1, ISBN = "9780743273565",
                      Genre = "Fiction", PublishedDate = new DateTime(1925, 4, 10),
             Quantity =10},

            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 12.50,
                      Barcode = "9780061120084", ShelfId = 2, ISBN = "9780061120084",
                      Genre = "Fiction", PublishedDate = new DateTime(1960, 7, 11) ,Quantity =12},

            new Book { Id = 3, Title = "1984", Author = "George Orwell", Price = 10.99,
                      Barcode = "9780451524935", ShelfId = 1, ISBN = "9780451524935",
                      Genre = "Dystopian", PublishedDate = new DateTime(1949, 6, 8) ,Quantity =71},
            new Book {Id = 4,Title = "Pride and Prejudice",Author = "Jane Austen",Price = 11.25,
                    Barcode = "9780141439518",ShelfId = 2,ISBN = "9780141439518",
                    Genre = "Classic Romance",PublishedDate = new DateTime(1813, 1, 28), Quantity = 13},
            new Book {Id = 5,Title = "The Hobbit",Author = "J.R.R. Tolkien",Price = 14.99,
                    Barcode = "9780547928227",ShelfId = 3,ISBN = "9780547928227",Genre = "Fantasy",
                    PublishedDate = new DateTime(1937, 9, 21), Quantity = 1},
            new Book {Id = 6, Title = "The Catcher in the Rye",Author = "J.D. Salinger",Price = 13.40,
                    Barcode = "9780316769488",ShelfId = 1,ISBN = "9780316769488",Genre = " Fiction",
                    PublishedDate = new DateTime(1951, 7, 16), Quantity = 14},
            new Book {Id = 7,Title = "The Da Vinci Code",Author = "Dan Brown",Price = 16.75,
                    Barcode = "9780307474278",ShelfId = 3,ISBN = "9780307474278",Genre = "Mystery",
                PublishedDate = new DateTime(2003, 4, 1), Quantity = 10},
            ];


        public Book Add(Book newBook)
        {
            newBook.Id = (_books.Last().Id) + 1;

            _books.Add(newBook);
            return newBook;

        }

        public bool Delete(int id)
        {
            return true;
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            var BookByAuthor= _books.Where(x => x.Author == author).ToList();
            return BookByAuthor;
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            var BookBygenre =_books.Where(x => x.Genre == genre).ToList();
            return BookBygenre;


        }

        public List<Book> GetBooksByPriceRange(double min, double max)
        {
            var Books =_books.Where(x => x.Price >= min && x.Price <= max).ToList();
            return Books;
        }

        public List<int> getShelfGenra(string genra)
        {

            var books =_books.Where(x => x.Genre.Equals(genra, StringComparison.OrdinalIgnoreCase)).ToList();

            if (books.Count > 0)
            {
                var shelf =_books.Where(shelf => books.Any(x => x.ShelfId == shelf.Id))
                     .Select(s => s.ShelfId)
                     .ToList();
                return shelf;
            }
            else { return null; }


        }

        public Book? GetById(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            return book != null ? book:null;
        }

        public Book Update(int id, Book updatedBook)
        {
            var book = GetById(id);
            if (book == null)
            {
                return null;
            }
            { 
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.PublishedDate = updatedBook.PublishedDate;
                book.Price = updatedBook.Price;
                book.Barcode = updatedBook.Barcode;
                book.ISBN = updatedBook.ISBN;
                book.Genre = updatedBook.Genre;
                book.ShelfId = updatedBook.ShelfId;
                book.Quantity = updatedBook.Quantity;

                return book;
            }
                 
    }

        public List<Book> GetBooksByShelf(int shelf)
        {
            var BookByShelf = _books.Where(x => x.ShelfId == shelf).ToList();
            return BookByShelf;
        }
    }
}
