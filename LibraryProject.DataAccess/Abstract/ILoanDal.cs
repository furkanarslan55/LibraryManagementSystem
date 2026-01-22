using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Abstract
{
    public  interface ILoanDal :IGenericRepository<Loan>
    {
        Task<List<Loan>> GetAllWithDetailsAsync();
    }
}
