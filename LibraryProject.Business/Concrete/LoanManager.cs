using AutoMapper;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.LoanDtos;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Concrete
{
    public class LoanManager(ILoanDal loanDal,IMapper mapper,IUserDal userDal,IBookDal bookDal) : ILoanService
    {
        private readonly ILoanDal _loanDal = loanDal;
        private readonly IMapper _mapper = mapper;
        private readonly IUserDal _userDal = userDal;
        private readonly IBookDal _bookDal = bookDal;
        public async Task LendBookAsync(LoanCreateDto loanCreateDto)
        {
            // KURAL 0.1: Böyle bir kitap var mı?
            var bookToCheck = await _bookDal.GetByIdAsync(loanCreateDto.BookId);
            if (bookToCheck == null)
            {
                throw new Exception("Böyle bir kitap bulunamadı! Lütfen geçerli bir Kitap ID giriniz.");
            }

            // KURAL 0.2: Böyle bir kullanıcı var mı?
            var userToCheck = await _userDal.GetByIdAsync(loanCreateDto.UserId);
            if (userToCheck == null)
            {
                throw new Exception("Böyle bir kullanıcı bulunamadı! Lütfen geçerli bir Kullanıcı ID giriniz.");
            }

       


            // KURAL 1: Kitap şu an başkasında mı? 
            var activeLoans = await _loanDal.GetAsync(x => x.BookId == loanCreateDto.BookId && x.ReturnDate == null);

            if (activeLoans != null) 
            {
                throw new Exception("Bu kitap şu an başkasında, ödünç verilemez!");
            }

            // KURAL 2: Kaydı oluştur (Aynen kalıyor)
            var newLoan = _mapper.Map<Loan>(loanCreateDto);
            newLoan.LoanDate = DateTime.Now;
            newLoan.IsReturned = false;

            await _loanDal.AddAsync(newLoan);
        }
        public async Task ReturnBookAsync(LoanReturnDto loanReturnDto)
        {
         
            var loan = await _loanDal.GetAsync(x => x.BookId == loanReturnDto.BookId && x.ReturnDate == null);

            // 2. KONTROL: Kayıt yoksa kitap zaten raftadır.
            if (loan == null)
            {
                throw new Exception("Bu kitap zaten kütüphanede! İade edilecek bir işlem bulunamadı.");
            }

            loan.ReturnDate = DateTime.Now; // Bugün döndü
            loan.IsReturned = true;         // Artık döndü olarak işaretle

        
             _loanDal.Update(loan);
        }

        public async Task<List<LoanDetailDto>> GetAllLoansAsync()
        {
            
            var loans = await _loanDal.GetAllWithDetailsAsync();

           
            var loanDtos = _mapper.Map<List<LoanDetailDto>>(loans);

            return loanDtos;
        }
    }





}
