using Ecommerce.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Entities.Concrete
{
    public class CartItem : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

    }
}
