using Ecommerce.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
