using AutoMapper;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.AuthorDtos;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;

namespace LibraryProject.Business.Concrete
{
    public class AuthorManager(IAuthorDal authorDal,IMapper mapper) : IAuthorService
    {
        private readonly IAuthorDal? _authorDal;
        private readonly IMapper? _mapper;
     

        public async Task AddAuthorAsync(AuthorAddDto authorAddDto)
        {
            var authorEntity = _mapper.Map<Author>(authorAddDto);
            // "await" ile Repository'nin işini bitirmesini bekliyoruz (ama thread bloklanmadan)
            await _authorDal.AddAsync(authorEntity);
        }

        public async Task<List<AuthorListDto>> GetAllAuthorsAsync()
        {
           
            var authorEntities = await _authorDal.GetAllAsync();
            var authorDtos = _mapper.Map<List<AuthorListDto>>(authorEntities);
            return authorDtos;
        }




    }
}
