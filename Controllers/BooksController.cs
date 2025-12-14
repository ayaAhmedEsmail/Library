using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController (IBookRepository  book) : ControllerBase
    {
       

        [HttpGet("getBooks")]
        public IActionResult getBooks() {

            return Ok(book.GetAll());

        }

        [HttpGet("getBooksById")]
        public IActionResult getBooksByID(int id)
        {
            var _book = book.GetById(id);
            if (_book == null) return NotFound("No books found with this ID"); else { return Ok(_book); } 
        }

        [HttpPut("EditBook")]
        public IActionResult editBook(Book _updatedbook, int id) {

            var updatedBook = book.Update(id,_updatedbook);
            if (updatedBook == null) return NotFound("No books found with this ID"); else return Ok(updatedBook);
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook(Book newBook)
        {
            book.Add(newBook);
            return Created($"api/books/{newBook.Id}", newBook);

        }

        [HttpGet("SearchByAuthor")]
        public IActionResult GetAuthors(string author)
        {
            return Ok(book.GetBooksByAuthor(author));
        }

        [HttpGet("SearchByShelf")]
        public IActionResult GetBookByShelf(int shelf) {
            var BookByShelf = book.GetBooksByShelf(shelf);
            return Ok(BookByShelf);
        }

        [HttpGet("PriceFilter")]
        public IActionResult searchByPrice(double min, double max) {
            return Ok(book.GetBooksByPriceRange(min, max));
        }


        [HttpGet("getShelfGenra")]
        public IActionResult getShelfGenra(string genra)
        {
           
             var shelf = book.GetBooksByGenre(genra);

            if (shelf.Count > 0)
                return Ok(shelf);
            
            else  return NotFound("No books found with this genre."); 
           
        }
    }
}
