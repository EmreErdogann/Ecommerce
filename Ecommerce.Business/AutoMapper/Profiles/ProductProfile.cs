using AutoMapper;
using Ecommerce.Core.DTos.ProductDTos;
using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductUpdateDto, Product>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)); ;
        }
    }
}
