using Ecommerce.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Entities.Concrete
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    } 
}
