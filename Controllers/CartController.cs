using Library.Models.Books;
using Library.Models.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartRepository saleRepository) : ControllerBase
    {

       [HttpGet("GetSales")]
      //public IActionResult GetSales()
      //  {
      //      var sales = saleRepository.GetAllSales();
      //      return Ok(sales);
      //  }


        [HttpGet("Show item cart")]
        public IActionResult GetBookinCart()
        {
            var booksInCart = saleRepository.GetCartItems();

            return Ok(booksInCart);
        }

        [HttpPost("addToCart")]
        public IActionResult addItem(int bookId, int quaintity) {
            var book = saleRepository.AddBookToCart(bookId, quaintity);

            return Ok(book);
        }

        [HttpDelete("clearCart")]
        public IActionResult ClearCart() {
            saleRepository.ClearCart();

            return Ok("Successfully cleared.");
        }

        [HttpDelete("RemoveBook")]
        public IActionResult RemoveBookFromCart(int id)
        {
            saleRepository.RemoveBookFromCart(id);

            return Ok("Successfully cleared.");
        }


        [HttpPost("BuyBook")]
        public IActionResult CreateSale(int bookId, int quentity)
        {
            var book = saleRepository.GetCartItems();

            Book book1 = saleRepository.SaleBook(bookId,quentity);

            return Created($"api/books/{book1.Title}", "New Sale Created");
        }


        [HttpGet("TotalItemsInCart")]
        public IActionResult getTotalItemsInCart()
        {
            var totalItems = saleRepository.GetNumItemsInCart();
            return Ok(totalItems);
        }



        [HttpPost("Buy")]
        public IActionResult CreateSaleforAllItems()
        {
            var book = saleRepository.SaleAllCart();

          //  Book book1 = saleRepository.SaleBook(bookId, quentity);
          
            return Created($"api/books/{book}", "New Sale Created");
        }


        [HttpGet("TotlaPrice")]
        public IActionResult getTotalPrice() {

            var totalprice = saleRepository.GetCartTotalPrice();

            return Ok(totalprice);
        }


    }
}
