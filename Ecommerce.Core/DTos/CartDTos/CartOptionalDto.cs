using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.CartDTos
{
    public class CartOptionalDto:DtoGetBase
    {
        public string UserId { get; set; }

        public int Id { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
