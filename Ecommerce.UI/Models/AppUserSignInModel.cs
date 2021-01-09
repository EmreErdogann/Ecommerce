using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.UI.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilmez")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parola:")]
        [Required(ErrorMessage = "Parola alanı boş geçilmez")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla:")]
        public bool RememberMe { get; set; }

    }
}
