using Library.Models.Books;

namespace Library.Models.Sales
{
    public class CartItems
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }
    }
}
