using Mvc_Proje.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Proje.ModelView
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adınızı girmediniz")]
        [StringLength(100, ErrorMessage = "Kullanıcı adınız 100 karakterden fazla olamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Adınızı girmediniz")]
        [StringLength(30, ErrorMessage = "Adınız 30 karakterden fazla olamaz")]
        [Display(Name = "Tam Adınız")]
        public string Ad_Soyad { get; set; }

        [Required(ErrorMessage = "Şifrenizi girmediniz")]
        [StringLength(20, ErrorMessage = "Şifreniz 20 karakterden fazla olamaz")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "e-Mail'inizi girmediniz")]
        [StringLength(100, ErrorMessage = "e-Mail'iniz 100 karakterden fazla olamaz")]
        [Display(Name = "e-Mail")]
        public string Mail { get; set; }

        public int ID { get; set; }


        public static implicit operator UserViewModel(User usr2)
        {
            UserViewModel usr1 = new UserViewModel();
            usr1.ID = usr2.ID;
            usr1.Ad_Soyad = usr2.Ad_Soyad;
            usr1.KullaniciAdi = usr2.KullaniciAdi;
            usr1.Mail = usr2.Mail;
            usr1.Sifre = usr2.Sifre;
            return usr1;
        }
    }
}