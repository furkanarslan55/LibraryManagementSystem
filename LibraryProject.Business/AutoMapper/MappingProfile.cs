using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryProject.Business.DTOs.BookDtos;
using LibraryProject.Entities.Concrete;

namespace LibraryProject.Business.AutoMapper
{
    public  class MappingProfile :Profile
    {
        public MappingProfile()
        {
           CreateMap<Book ,BookListDto>(). ReverseMap();
            CreateMap<BookAddDto, Book>().ReverseMap();
        }
    }
}
