using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfLoanDal:EfGenericRepository<Loan, LibraryContext> ,ILoanDal
    {
        public EfLoanDal(LibraryContext context) : base(context)
        {
        }
        public async Task<List<Loan>> GetAllWithDetailsAsync()
        {
           
            return await _context.Loans
                .Include(x => x.Book)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
