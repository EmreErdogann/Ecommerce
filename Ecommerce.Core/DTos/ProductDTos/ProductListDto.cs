using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.ProductDTos
{
    public class ProductListDto : DtoGetBase
    {
        public IList<Product> Product { get; set; }
    
    }
}
