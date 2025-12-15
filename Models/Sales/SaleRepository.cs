using Library.Models.Books;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace Library.Models.Sales
{

    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales = new();
        private readonly IBookRepository _bookRepository;
        private readonly List<CartItems> _cart = new();

        public SaleRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        // Add book to cart if available in requested quantity
        public List<Book> AddBookToCart(int bookId, int quantity)
        {
            // Validate book existence
            var book = _bookRepository.GetById(bookId);
            if (book == null)
                throw new Exception("Book not found.");

            // Check availability
            var available = checkBookAvailability(bookId, quantity);
            if (!available)
                throw new Exception("Book is not available in the requested quantity.");

            // check if book is already in cart
            var existingCartItem = _cart.FirstOrDefault(c => c.BookId == bookId);

            if (existingCartItem != null)
            {
                // Update quantity if already in cart
                existingCartItem.Quantity += quantity;
                return GetCartItems();


            }
            else
            {
                // Add new book to cart
                _cart.Add(new CartItems
                {
                    BookId = bookId,
                    Quantity = quantity
                });
            }
            return GetCartItems();

        }


        // Calculate total price for the books in the cart
        public double calculateTotalPrice(int bookId, int quantity)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null) return 0;
            var totalPrice = book.Price * quantity;
            return totalPrice;
        }

        // Check if the requested quantity of the book is available
        public bool checkBookAvailability(int bookId, int quantity)
        {

            var book = _bookRepository.GetById(bookId);
            if (book == null)
            {
                return false;
            }
            return book.Quantity >= quantity;
        }
        public List<Sale> GetAllSales()
        {
            var sales = _sales.ToList();
            return sales;
        }

        public int getBookCount(int bookId)
        {
            var book = _bookRepository.GetById(bookId);

            if (book == null) return 0;

            if (book.Quantity < 0)
                throw new Exception("Book is out of stock.");
            else
                return book.Quantity;
           
        }

        // Get all items currently in the cart
        public List<Book> GetCartItems()
        {
            var cartBooks= new List<Book>();
            foreach (var item in _cart)
            {
                var book = _bookRepository.GetById(item.BookId);
                if (book != null)
                {
                    cartBooks.Add(book);
                }
            }
            return cartBooks;

        }
        public List<Sale> SaleAllCart()
        {
            var salesList = new List<Sale>();

            if (_cart.Count == 0)
                throw new Exception("Cart is empty. Add items to cart first.");

            Console.WriteLine($"Process:{_cart.Count} item");

            foreach (var cartItem in _cart)
            {

                Console.WriteLine($"Process:{cartItem.BookId}, Q={cartItem.Quantity}");
                if (!checkBookAvailability(cartItem.BookId, cartItem.Quantity))
                {

                    Console.WriteLine($"Process:{cartItem.BookId} Q={cartItem.Quantity}");
                    throw new Exception($"Book ID {cartItem.BookId} is not available in quantity {cartItem.Quantity}.");
                }

            }
            foreach (var cartItem in _cart)
            {

                var book = _bookRepository.GetById(cartItem.BookId);

                if (book == null)
                    throw new Exception("Book not found.");

                var sale = new Sale
                {
                    BookId = cartItem.BookId,
                    SaleDate = DateTime.Now,
                    Quantity = cartItem.Quantity,
                    UnitPrice = book.Price,
                    TotalPrice = cartItem.BookId* cartItem.Quantity
                };
                _sales.Add(sale);
                salesList.Add(sale);

                // Update book quantity in the repository
                var newQuantity = updateQuentity(cartItem.BookId, cartItem.Quantity);
                Console.WriteLine($"After sale - Book ID {book.Id}: New Quantity = {newQuantity}");
            }
            // Clear the cart before processing the sale
            ClearCart();
            return salesList;
        }

        public Book SaleBook(int bookId, int quantity)
        {
            // check availability before creating sale
            if (!checkBookAvailability(bookId, quantity))
                throw new Exception("Insufficient quantity available for sale.");

            var book = _bookRepository.GetById(bookId);

            if (book == null)
                throw new Exception("Book not found.");

            var sale = new Sale
            {
                BookId = bookId,
                SaleDate = DateTime.Now,
                Quantity = quantity,
                UnitPrice = book.Price,
                TotalPrice = calculateTotalPrice(bookId, quantity)
            };
            _sales.Add(sale);
           
            // Update book quantity in the repository
            updateQuentity(bookId, quantity);

           // Clear the cart before processing the sale
            ClearCart();
            return book;
            
        }

        public void ClearCart()
        {
            _cart.Clear();
        }

        int updateQuentity(int bookId,int quantity) {

            var book = _bookRepository.GetById(bookId);

            if (book != null && book.Quantity >= quantity) {

                book.Quantity -= quantity;
                _bookRepository.Update(bookId, book);
            }
            else throw new Exception($"Cannot complete sale. Only {book.Quantity} books available, but trying to sell {quantity}.");
            return book.Quantity;
        }

        public double GetCartTotalPrice()
        {
            double total = 0;
            if (_cart.Count == 0)
            {
                Console.WriteLine("cart is emply");
                return total = 0;
                
            }
            else {

                foreach (var cartItem in _cart) {
                    var book = _bookRepository.GetById(cartItem.BookId);
                    if (book != null) {

                        var totalperItem = book.Price * cartItem.Quantity;
                        total = total + totalperItem;
                    }
                }
            }
            return total;
        }

        public int GetNumItemsInCart()
        {
           var totalItems = 0;
            totalItems = _cart.Sum(item => item.Quantity);
            return totalItems;
        }
    }
}
