using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryProject.Business.DTOs.AuthorDtos;
using LibraryProject.Business.DTOs.BookDtos;
using LibraryProject.Entities.Concrete;

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
        }
    }
}
