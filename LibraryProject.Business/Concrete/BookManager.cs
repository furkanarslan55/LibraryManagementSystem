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


        public void AddBook(BookAddDto bookAddDto)
        {
            if ( bookAddDto.Price <= 0)
            {
                throw new ArgumentException("Book price must be greater than zero.");
            }


            if (string.IsNullOrWhiteSpace(bookAddDto.Title))
            {
                throw new ArgumentException("Book title cannot be empty.");
            }

            var bookEntity = _mapper.Map<Book>(bookAddDto);

            _bookDal.Add(bookEntity);


        }

        public List<BookListDto> GetAllBooks()
        {

            var bookEntities = _bookDal.GetAll();

            var bookDtos = _mapper.Map<List<BookListDto>>(bookEntities);

           

            return bookDtos;


        }


    }
}
