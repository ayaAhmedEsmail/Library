namespace Library.Models
{
    public class LibraryDataClass
    {

        public static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 15.99,
                      Barcode = "9780743273565", ShelfId = 1, ISBN = "9780743273565",
                      Genre = "Fiction", PublishedDate = new DateTime(1925, 4, 10) },

            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 12.50,
                      Barcode = "9780061120084", ShelfId = 2, ISBN = "9780061120084",
                      Genre = "Fiction", PublishedDate = new DateTime(1960, 7, 11) },

            new Book { Id = 3, Title = "1984", Author = "George Orwell", Price = 10.99,
                      Barcode = "9780451524935", ShelfId = 1, ISBN = "9780451524935",
                      Genre = "Dystopian", PublishedDate = new DateTime(1949, 6, 8) },
            new Book {Id = 4,Title = "Pride and Prejudice",Author = "Jane Austen",Price = 11.25,
                    Barcode = "9780141439518",ShelfId = 2,ISBN = "9780141439518",
                    Genre = "Classic Romance",PublishedDate = new DateTime(1813, 1, 28)},
            new Book {Id = 5,Title = "The Hobbit",Author = "J.R.R. Tolkien",Price = 14.99,
                    Barcode = "9780547928227",ShelfId = 3,ISBN = "9780547928227",Genre = "Fantasy",
                    PublishedDate = new DateTime(1937, 9, 21)},
            new Book {Id = 6, Title = "The Catcher in the Rye",Author = "J.D. Salinger",Price = 13.40,
                    Barcode = "9780316769488",ShelfId = 1,ISBN = "9780316769488",Genre = " Fiction",
                    PublishedDate = new DateTime(1951, 7, 16)},
            new Book {Id = 7,Title = "The Da Vinci Code",Author = "Dan Brown",Price = 16.75,
                    Barcode = "9780307474278",ShelfId = 3,ISBN = "9780307474278",Genre = "Mystery",
                PublishedDate = new DateTime(2003, 4, 1)},

        };


        public static List<Shelf> Shelves = new List<Shelf>
        {
            new Shelf { Id = 1, ShelfNumber = "A1", Location = "Section A", Capacity = 50 },
            new Shelf { Id = 2, ShelfNumber = "B1", Location = "Section B", Capacity = 40 },
            new Shelf { Id = 3, ShelfNumber = "C1", Location = "Section C", Capacity = 60 }
        };


    }
}
