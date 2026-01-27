using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataAccess.Concrete.EntityFramework
{
    public class EfBookCommentDal :EfGenericRepository<BookComment,LibraryContext> , IBookCommentDal
    {
        public EfBookCommentDal(LibraryContext context) : base(context)
        {
        }

    }
}
