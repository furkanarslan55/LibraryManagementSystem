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
        Task DeleteBookAsync(int id);
        Task UpdateBookAsync(BookUpdateDto bookUpdateDto);
        Task<List<BookListDto>> SearchBooksAsync(string? text, int? categoryId, int pageNumber = 1, int pageSize = 10);
        Task<List<BookListDto>> SearchBooksAsync(string keyword);
    }
}
