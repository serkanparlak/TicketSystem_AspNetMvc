using Mvc_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje.Controllers
{
    public class HomeController : Controller
    {
        TicketSystemsContext edm = new TicketSystemsContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User veri)
        {
            User kisi = edm.Users.SingleOrDefault(x => x.KullaniciAdi == veri.KullaniciAdi & x.Sifre == veri.Sifre);
            if (kisi == null)
                return Json(false);
            else
            {
                if (kisi.Rol == "Admin")
                {
                    Session["Admin"] = kisi.KullaniciAdi;
                    return Json("Admin");
                }
                else
                {
                    Session["Kullanıcı"] = kisi.KullaniciAdi;
                    return Json("Kullanıcı");
                }
            }
        }
        public void KullaniciDegisti(string kadi)
        {
            Session["Kullanıcı"] = kadi;
        }
        public void Logout()
        {
            Session.Abandon();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(User data)
        {
            try
            {
                User yeni = new User();
                yeni.Ad_Soyad = data.Ad_Soyad;
                yeni.KullaniciAdi = data.KullaniciAdi;
                yeni.Mail = data.Mail;
                yeni.Sifre = data.Sifre;
                yeni.Dogum = data.Dogum;
                yeni.Rol = "Kullanıcı";
                edm.Users.Add(yeni);
                edm.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        public ActionResult KullaniciKontrolEt(string kullaniciAdi)
        {
            User user = edm.Users.Where(u => u.KullaniciAdi == kullaniciAdi).FirstOrDefault();
            if (user != null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public ActionResult EmailKontrolEt(string gelenMail)
        {
            User mail = edm.Users.SingleOrDefault(x => x.Mail == gelenMail);
            if (mail != null)
                return Json(true);
            else
                return Json(false);

        }
    }
}
