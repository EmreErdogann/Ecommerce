using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Core.DTos.ProductDTos
{
    public class ProductAddDto : DtoGetBase
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }


        [DisplayName("Ürün Resim")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string ImageUrl { get; set; }


        [DisplayName("Fiyat alanı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public decimal Price { get; set; }


        [DisplayName("Kategori Alanı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int CategoryId { get; set; }
        public IList<Category> Categories { get; set; }


    }
}
