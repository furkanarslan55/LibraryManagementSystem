using LibraryProject.Business.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Abstract
{
    public interface IBookCommentService
    {
        Task AddCommentAsync(AddCommentDto dto);
        Task<List<ListCommentDto>> GetCommentsByBookIdAsync(int bookId);
    }
}
