using AutoMapper;
using Ecommerce.Core.DTos.CategoryDTos;
using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)); ;
        }
    }
}
