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
            // ADIM 1: Kitabın Kendisini Getir (Stok bilgisini öğrenmek için)
            var book = await _bookDal.GetByIdAsync(loanCreateDto.BookId);

            // Kitap hiç yoksa zaten veremeyiz (Validation)
            if (book == null)
            {
                throw new Exception("Böyle bir kitap bulunamadı!");
            }

            // ADIM 2: Şu an bu kitaptan kaç tanesi dışarıda (İade edilmemiş)?
            // İstatistik bölümünde generic repository'e Count metodu eklemiştik, hatırladın mı? Onu kullanıyoruz.
            // Sorgu: BookId'si tutan VE ReturnDate'i NULL olanları say.
            var activeLoanCount = await _loanDal.GetCountAsync(x => x.BookId == loanCreateDto.BookId && x.ReturnDate == null);

            // ADIM 3: Matematiksel Karar Anı 🧮
            // Eğer (Dışarıdakiler >= Stok) ise kapasite dolmuş demektir.
            if (activeLoanCount >= book.Stock)
            {
                throw new Exception("Üzgünüz, bu kitabın tüm kopyaları şu an ödünç verilmiş durumda. Stokta yok.");
            }

            

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
