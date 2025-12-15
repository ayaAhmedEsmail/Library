using Library.Models.Books;

namespace Library.Models
{
    public interface ILibrary
    {
        public string name { get; }
        public List<Book> Book { get; }
        public List<Shelf> Shelf { get; }


        

    }
}
