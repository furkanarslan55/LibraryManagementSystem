using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.AuthorDtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController(IAuthorService authorService) : Controller
    {
        private readonly IAuthorService _authorService;


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAllAuthorsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorAddDto dto)
        {
            await _authorService.AddAuthorAsync(dto);
            return Ok("Yazar eklendi.");
        }



    }

}
