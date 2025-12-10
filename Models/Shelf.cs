namespace Library.Models
{
    public class Shelf
    {
            public int Id { get; set; }
            public string ShelfNumber { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public int Capacity { get; set; }
            public List<Book> Books { get; set; } = new List<Book>();
    }
}
