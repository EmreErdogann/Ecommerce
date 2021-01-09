using AutoMapper;
using Ecommerce.Core.DTos.CartDTos;
using Ecommerce.Core.DTos.CategoryDTos;
using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.AutoMapper.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartAddDto, Cart>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

        }
    }
}
