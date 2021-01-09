using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos.CategoryDTos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }

    }
}
