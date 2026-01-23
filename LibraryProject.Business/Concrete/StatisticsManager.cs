using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.StatisticsDtos;
using LibraryProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Concrete
{
    // Bize lazım olan tüm katipleri (DAL) çağırıyoruz
    public class StatisticsManager(
        IBookDal bookDal,
        IUserDal userDal,
        ILoanDal loanDal,
        ICategoryDal categoryDal) : IStatisticsService
    {
        private readonly IBookDal _bookDal = bookDal;
        private readonly IUserDal _userDal = userDal;
        private readonly ILoanDal _loanDal = loanDal;
        private readonly ICategoryDal _categoryDal = categoryDal;

        public async Task<DashboardDto> GetDashboardStatistics()
        {
            var dashboardDto = new DashboardDto();

            // 1. Toplam Kitaplar (Filtre yok, hepsini say)
            dashboardDto.TotalBooks = await _bookDal.GetCountAsync();

            // 2. Toplam Üyeler
            dashboardDto.TotalUsers = await _userDal.GetCountAsync();

            // 3. Toplam Kategoriler
            dashboardDto.TotalCategories = await _categoryDal.GetCountAsync();

            // 4. Aktif Ödünçler (ReturnDate'i NULL olanları say)
            // İşte filtreli sayma burada işe yarıyor!
            dashboardDto.ActiveLoans = await _loanDal.GetCountAsync(x => x.ReturnDate == null);

            return dashboardDto;
        }
    }
}
