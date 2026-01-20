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
     
        public BookManager(IBookDal bookDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }


        public async Task AddBookAsync(BookAddDto bookAddDto)
        {
            var bookEntity = _mapper.Map<Book>(bookAddDto);

            
            await _bookDal.AddAsync(bookEntity);
        }

        public async Task <List<BookListDto>> GetAllBooksAsync()
        {
        
            var bookEntities = await _bookDal.GetBooksWithCategoryAsync();

            var bookDtos = _mapper.Map<List<BookListDto>>(bookEntities);

            return bookDtos;
        }


        public async Task DeleteBookAsync(int id)
        {
            var bookEntity = await _bookDal.GetByIdAsync(id);
            if (bookEntity is null)
            {
                throw new Exception("Book not found");
            }
            _bookDal.Delete(bookEntity);
        }

        public async Task UpdateBookAsync(BookUpdateDto bookUpdateDto)
        {
            var bookEntity = await _bookDal.GetByIdAsync(bookUpdateDto.Id);
            if (bookEntity is null)
            {
                throw new Exception("Book not found");
            }
            _mapper.Map(bookUpdateDto, bookEntity); // Update the existing entity with new values
            _bookDal.Update(bookEntity);
        }

    }
}
