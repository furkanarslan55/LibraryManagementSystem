using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.AuthDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            // Servis hata fırlatırsa (Kullanıcı yok vs.) Global Exception Middleware yakalar.
            // O yüzden try-catch yazmıyoruz.
            var token = await _authService.LoginAsync(userForLoginDto);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // Önce kullanıcı var mı diye bakmak iyi bir pratiktir (Business'ta da yapılabilir ama burada basitçe yapalım)
            var userExists = await _authService.UserExistsAsync(userForRegisterDto.Email);
            if (userExists)
            {
                return BadRequest("Bu mail adresi zaten kullanılıyor.");
            }

            var token = await _authService.RegisterAsync(userForRegisterDto);
            return Ok(token);
        }
    }
}
