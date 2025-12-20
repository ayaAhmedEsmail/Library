using Library.Models.Books;
using Library.Models.Sales;

namespace Library.Models.Sales
{
    public interface ICartRepository
    {
        bool checkBookAvailability(int bookId, int quantity);

        double calculateTotalPrice(int bookId, int quantity);

        int getBookCount(int bookId);

      
        List<CartItems> AddBookToCart(int bookId, int quantity);
        Book SaleBook(int bookId, int quantity);
        double GetCartTotalPrice();
       
        List<Sales> SaleAllCart();

        List<CartItems> GetCartItems();
        int GetNumItemsInCart();

        void RemoveBookFromCart(int bookId);
        void ClearCart();
     
    }
}



