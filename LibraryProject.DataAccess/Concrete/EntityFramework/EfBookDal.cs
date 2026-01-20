using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfGenericRepository<Book, LibraryContext>, IBookDal
    {
        public EfBookDal(LibraryContext context) : base(context)
        {
        }
        public async Task<List<Book>> GetBooksWithCategoryAsync()
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .ToListAsync();
        }
    }


}
