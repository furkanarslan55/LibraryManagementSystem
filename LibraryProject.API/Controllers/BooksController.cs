using Microsoft.AspNetCore.Mvc;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.BookDtos;
using Microsoft.AspNetCore.Authorization;


namespace LibraryProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok("Kitap başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto bookUpdateDto)
        {
            await _bookService.UpdateBookAsync(bookUpdateDto);
            return Ok("Kitap başarıyla güncellendi.");
        }
       

        [HttpGet("search")]
        // URL Örneği: /api/Books/search?text=Harry&pageNumber=2&pageSize=5
        public async Task<IActionResult> SearchBooks(
    [FromQuery] string? text,
    [FromQuery] int? categoryId,
    [FromQuery] int pageNumber = 1, // Göndermezse 1 kabul et
    [FromQuery] int pageSize = 10   // Göndermezse 10 kabul et
    )
        {
            var result = await _bookService.SearchBooksAsync(text, categoryId, pageNumber, pageSize);
            return Ok(result);
        }
    }
}
