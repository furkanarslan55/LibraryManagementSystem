using AutoMapper;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.BookDtos;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<BookListDto>> SearchBooksAsync(string? text, int? categoryId, int pageNumber = 1, int pageSize = 10)
        {
     
            Expression<Func<Book, bool>> filter = x =>
                (string.IsNullOrEmpty(text) || x.Title.Contains(text)) &&
                (categoryId == null || x.CategoryId == categoryId);

            var books = await _bookDal.GetAllPagedAsync(filter, pageNumber, pageSize);

      
            var bookDtos = _mapper.Map<List<BookListDto>>(books);

            return bookDtos;
        }
        public async Task<List<BookListDto>> SearchBooksAsync(string keyword)
        {
            // 1. Validasyon: Boş arama yapılmasın
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 3)
            {
                throw new Exception("Arama yapmak için en az 3 karakter girmelisiniz.");
            }

            // 2. Küçük Harf Duyarlılığı (Case Insensitive)
            // Veritabanındaki 'JAVA' ile aranan 'java' eşleşsin diye keyword'ü küçültüyoruz.
            var searchKey = keyword.ToLower();

            // 3. Veritabanı Sorgusu (LINQ)
            // DAL katmanındaki "GetAllAsync" metodu içine bir filtre (Expression) alabiliyor.
            var books = await _bookDal.GetAllAsync(x =>
                x.Title.ToLower().Contains(searchKey) 
             
            );

            // 4. Mapping (Entity -> DTO)
            return _mapper.Map<List<BookListDto>>(books);
        }

    }
}
