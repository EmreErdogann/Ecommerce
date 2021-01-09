using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.CategoryDTos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }

    }
}
