using LibraryProject.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Business.DTOs.BookDtos;
using LibraryProject.Entities.Concrete;
using AutoMapper;

namespace LibraryProject.Business.Concrete
{
    public class BookManager : IBookService
    {

        private readonly IBookDal _bookDal;
        private readonly IMapper _mapper;
        public BookManager(IBookDal bookDal, IMapper mapper )
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }


        public async Task AddBookAsync(BookAddDto bookAddDto)
        {
            var bookEntity = _mapper.Map<Book>(bookAddDto);

            // "await" ile Repository'nin işini bitirmesini bekliyoruz (ama thread bloklanmadan)
            await _bookDal.AddAsync(bookEntity);
        }

        public async Task<List<BookListDto>> GetAllBooksAsync()
        {
            // _bookDal.GetAll() ARTIK YOK. GetAllAsync() var.
            var bookEntities = await _bookDal.GetBooksWithCategoryAsync();

            var bookDtos = _mapper.Map<List<BookListDto>>(bookEntities);

            return bookDtos;
        }


    }
}
