using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IBookCommentService _commentService;

        public CommentsController(IBookCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize] // Sadece giriş yapanlar yorum atabilir
        public async Task<IActionResult> Add([FromBody] AddCommentDto dto)
        {
            await _commentService.AddCommentAsync(dto);
            return Ok("Yorumunuz başarıyla eklendi.");
        }

        [HttpGet("{bookId}")]
        // [AllowAnonymous] // Yorumları herkes okuyabilsin (İsteğe bağlı)
        public async Task<IActionResult> GetByBook(int bookId)
        {
            var result = await _commentService.GetCommentsByBookIdAsync(bookId);
            return Ok(result);
        }
    }
}
