using LibraryProject.Business.DTOs.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Abstract
{
    public interface IAuthorService
    {
        Task<List<AuthorListDto>> GetAllAuthorsAsync();
        Task AddAuthorAsync(AuthorAddDto authorAddDto);

    }
}
