using Library.Models.Books;

namespace Library.Models.Sales
{
    public interface ISaleRepository
    {
        bool checkBookAvailability(int bookId, int quantity);

        double calculateTotalPrice(int bookId, int quantity);

        int getBookCount(int bookId);

      
        List<Book> AddBookToCart(int bookId, int quantity);
        Book SaleBook(int bookId, int quantity);
        double GetCartTotalPrice();


        List<Sale> GetAllSales();
       
        List<Sale> SaleAllCart();

        List<Book> GetCartItems();
        int GetNumItemsInCart();
        void ClearCart();
     
    }
}