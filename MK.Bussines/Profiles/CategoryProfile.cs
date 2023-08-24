using AutoMapper;
using MK.Model.Dtos.Category;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>().ForMember(dst => dst.Books, x => x.MapFrom(src => src.Books));

            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }

    }
}
