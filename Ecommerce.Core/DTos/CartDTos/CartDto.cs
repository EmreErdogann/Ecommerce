using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.CartDTos
{
    public class CartDto : DtoGetBase
    {
        public Cart Cart { get; set; }

    }
}
