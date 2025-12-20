using Library.Models.Books;

namespace Library.Models.Sales
{
    public class Sales
    {
        public int Id { get; set; }
        public int BookId { get; set; }
       public Book Book { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }


    }
}
