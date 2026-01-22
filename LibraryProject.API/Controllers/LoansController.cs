using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.LoanDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("lend")]
        public async Task<IActionResult> LendBook(LoanCreateDto loanCreateDto)
        {
            await _loanService.LendBookAsync(loanCreateDto);
            return Ok("Kitap başarıyla ödünç verildi. İyi okumalar!");
        }
        [HttpPut("return")]
        public async Task<IActionResult> ReturnBook(LoanReturnDto loanReturnDto)
        {
            await _loanService.ReturnBookAsync(loanReturnDto);
            return Ok("Kitap başarıyla iade alındı. Teşekkürler!");
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllLoans()
        {
            var result = await _loanService.GetAllLoansAsync();
            return Ok(result);
        }
    }
}
