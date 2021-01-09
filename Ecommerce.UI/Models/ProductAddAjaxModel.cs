using Ecommerce.Core.DTos.ProductDTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.UI.Models
{
    public class ProductAddAjaxModel
    {
        public ProductAddDto ProductAddDto { get; set; }
        public string UrunAddPartial { get; set; }
        public ProductDto ProductDto { get; set; }

    }
}
