using LibraryProject.Business.DTOs.LoanDtos;

namespace LibraryProject.Business.Abstract
{
    public interface ILoanService 
    {
        Task LendBookAsync(LoanCreateDto loadCreateDto);
        Task ReturnBookAsync (LoanReturnDto loanReturnDto);
        Task<List<LoanDetailDto>> GetAllLoansAsync();
    }
}
