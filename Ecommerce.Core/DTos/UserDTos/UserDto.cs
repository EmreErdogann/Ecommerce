using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.UserDTos
{
    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
    }
}
