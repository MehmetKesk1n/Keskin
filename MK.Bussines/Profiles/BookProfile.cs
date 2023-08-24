using AutoMapper;
using MK.Model.Dtos.Book;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookGetDto>()
               .ForMember(dst => dst.CategoryID,
                           X => X.MapFrom(src => src.Category.CategoryID));
            CreateMap<Book, BookGetDto>()
               .ForMember(dst => dst.CategoryName,
                           X => X.MapFrom(src => src.Category.CategoryName));
            CreateMap<BookPutDto, Book>();
            CreateMap<BookPostDto, Book>();
        }
    }
}
