using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.UI.Models
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilmez")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parola:")]
        [Required(ErrorMessage = "Parola alanı boş geçilmez")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parolanızı Tekrar Girin:")]
        [Compare("Password", ErrorMessage = "Parolanız uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Geçersiz Email")]
        [Required(ErrorMessage = "Email alanı boş geçilmez")]
        public string Email { get; set; }


        [Display(Name = "Adınız :")]
        [Required(ErrorMessage = "Ad alanı boş geçilmez")]
        public string Name { get; set; }

        [Display(Name = "Soyadınız :")]
        [Required(ErrorMessage = "Soyad alanı boş geçilmez")]
        public string Surname { get; set; }

    }
}
