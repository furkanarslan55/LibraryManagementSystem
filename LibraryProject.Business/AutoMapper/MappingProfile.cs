using AutoMapper;
using LibraryProject.Business.DTOs.AuthorDtos;
using LibraryProject.Business.DTOs.BookDtos;
using LibraryProject.Business.DTOs.Comment;
using LibraryProject.Business.DTOs.FavoriteDtos;
using LibraryProject.Business.DTOs.LoanDtos;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.AutoMapper
{
    public  class MappingProfile :Profile
    {
        public MappingProfile()
        {
           CreateMap<Book ,BookListDto>()
               .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName))
                .ReverseMap();
            CreateMap<BookAddDto, Book>().ReverseMap();
            CreateMap<Author,AuthorListDto>().ReverseMap();
            CreateMap<AuthorAddDto, Author>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();

            CreateMap<LoanCreateDto, Loan>();
            CreateMap<Favorite, FavoriteAddDto>().ReverseMap();
            CreateMap<Favorite, FavoriteListDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
    .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.Book.Price));
            CreateMap<AddCommentDto, BookComment>();

            CreateMap<BookComment, ListCommentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
            CreateMap<Loan, LoanDetailDto>()
    .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Title)) // Kitabın Adını Al
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)); // Ad Soyad Birleştir
        }
    }
}
