using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal :EfGenericRepository<Category,LibraryContext> , ICategoryDal
    {
        public EfCategoryDal(LibraryContext context) : base(context)
        {
        }
    }
}
