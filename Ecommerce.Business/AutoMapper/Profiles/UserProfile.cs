using AutoMapper;
using Ecommerce.Core.DTos.UserDTos;
using Ecommerce.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Business.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>().ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
        }

    }
}
