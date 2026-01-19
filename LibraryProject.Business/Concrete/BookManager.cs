using LibraryProject.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Business.DTOs.BookDtos;
using LibraryProject.Entities.Concrete;


namespace LibraryProject.Business.Concrete
{
    public class BookManager : IBookService
    {

        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
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

            Book bookEntity = new Book();
            bookEntity.Title = bookAddDto.Title;
            bookEntity.Price = bookAddDto.Price;
            bookEntity.CategoryId = bookAddDto.CategoryId;

            _bookDal.Add(bookEntity);


        }

        public List<BookListDto> GetAllBooks()
        {

            var bookEntities = _bookDal.GetAll();

            List<BookListDto> bookDtos = new List<BookListDto>();


            foreach( var item in bookEntities)
            {
                bookDtos.Add(new BookListDto
                {


                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price,
                    CategoryName = "Kategori bilgisi dah sonra eklenecek"


                });

          



            }


            return bookDtos;


        }


    }
}
