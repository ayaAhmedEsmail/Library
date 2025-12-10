using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
       

        [HttpGet("getBooks")]
        public IActionResult getBooks() {


            return Ok(LibraryDataClass.Books.ToList());

        }
        [HttpGet("getBooksById")]
        public IActionResult getBooksByID(int id)
        {
           var book= LibraryDataClass.Books.FirstOrDefault(x => x.Id == id);
            if (book != null) { return Ok(book); } else return NotFound("No books found with this ID");
            

        }

        [HttpPut("EditBook")]
        public IActionResult editBook(Book _updatedbookint, int id) {

            var book = LibraryDataClass.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {

                book.Title = _updatedbookint.Title;
                book.Author = _updatedbookint.Author;
                book.PublishedDate = _updatedbookint.PublishedDate;
                book.Price = _updatedbookint.Price;
                book.Barcode = _updatedbookint.Barcode;
                book.ISBN = _updatedbookint.ISBN;
                book.Genre = _updatedbookint.Genre;
                book.ShelfId = _updatedbookint.ShelfId;

                return Ok(book);
            }
            else return NotFound("No books found with this");
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook(Book newBook)
        {
             newBook.Id = ( LibraryDataClass.Books.Last().Id)+1;

            LibraryDataClass.Books.Add(newBook);

            return Created($"api/books/{newBook.Id}", newBook);

        }

        [HttpGet("SearchByAuthor")]
        public IActionResult GetAuthors(string author)
        {
            var BookByShelf = LibraryDataClass.Books.Where(x => x.Author == author)
                //.Select(x=>x.Title)
                .ToList();
            return Ok(BookByShelf);
        }

        [HttpGet("BookByShelf")]
        public IActionResult GetBookByShelf(int shlefId) {
            var BookByShelf = LibraryDataClass.Books.Where(x => x.ShelfId == shlefId).ToList();
            return Ok(BookByShelf);
        }

        [HttpGet("PriceFilter")]
        public IActionResult searchByPrice(double min, double max) {
            var Books = LibraryDataClass.Books.Where(x => x.Price >= min && x.Price <= max).ToList();
            return Ok(Books);
        }


        [HttpGet("getShelfGenra")]
        public IActionResult getShelfGenra(string genra)
        {
           
             var books = LibraryDataClass.Books.Where(x => x.Genre.Equals( genra,StringComparison.OrdinalIgnoreCase)).ToList();

            if (books.Count > 0)
            {
                var shelf=LibraryDataClass.Shelves
                    .Where(shelf=>books.Any(x=>x.ShelfId==shelf.Id))
                     .Select(s => s.ShelfNumber)
                     .ToList();
                return Ok(shelf);
            }
            else { return NotFound("No books found with this genre."); }
           
        }
    }
}
