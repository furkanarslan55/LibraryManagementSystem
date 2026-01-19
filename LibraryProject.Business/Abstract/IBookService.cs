using LibraryProject.Business.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Abstract
{
    public interface IBookService
    {
        Task<List<BookListDto>> GetAllBooksAsync();
        Task AddBookAsync(BookAddDto bookAddDto);
    }
}
