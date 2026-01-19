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
        // Dönüş tipi: async Task<IActionResult>
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAllBooksAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookAddDto bookAddDto)
        {
            // Validasyon ve Hata yönetimi (Middleware) olduğu için burası tertemiz.
            await _bookService.AddBookAsync(bookAddDto);
            return Ok("Kitap başarıyla eklendi.");
        }
    }
}
