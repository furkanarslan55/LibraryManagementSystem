using Microsoft.AspNetCore.Mvc;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.BookDtos;


namespace LibraryProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {

        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]

        public IActionResult Add(BookAddDto bookAddDto)
        {

            
            
                _bookService.AddBook(bookAddDto);
                return Ok();
            
         




        }
    }
}
