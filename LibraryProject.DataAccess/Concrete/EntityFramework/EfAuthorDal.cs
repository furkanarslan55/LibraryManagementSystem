using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfAuthorDal :EfGenericRepository<Author,LibraryContext> , IAuthorDal
    {
        public EfAuthorDal(LibraryContext context) : base(context)
        {
        }
    }
}
