using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.FavoriteDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FavoriteAddDto dto)
        {
            await _favoriteService.AddFavoriteAsync(dto);
            return Ok("Kitap favorilere eklendi.");
        }

        [HttpGet("my-favorites")]
        public async Task<IActionResult> GetMyFavorites()
        {
            var result = await _favoriteService.GetMyFavoritesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _favoriteService.RemoveFavoriteAsync(id);
            return Ok("Favorilerden çıkarıldı.");
        }
    }
}