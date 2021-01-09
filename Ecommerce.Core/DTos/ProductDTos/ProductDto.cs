using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.ProductDTos
{
    public class ProductDto : DtoGetBase
    {
        public Product Product { get; set; }

    }
}
