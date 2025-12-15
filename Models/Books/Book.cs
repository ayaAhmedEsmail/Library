namespace Library.Models.Books
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; } 
        public required string Author { get; set; } 
        public double Price { get; set; }
        public string? Barcode { get; set; } 
        public int ShelfId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? ISBN { get; set; }
        public string? Genre { get; set; }

        public int Quantity { get; set; }

    }
}
