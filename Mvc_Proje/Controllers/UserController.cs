using Mvc_Proje.Models;
using Mvc_Proje.ModelView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje.Controllers
{
    public class UserController : Login_UserController
    {
        TicketSystemsContext edm = new TicketSystemsContext();
        public ActionResult Index()
        {
            string kl = Session["Kullanıcı"] as string;
            var kul = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kl);
            ViewBag.username = kul.Ad_Soyad;

            var tick = edm.Tickets.Where(y => y.User_ID == kul.ID).Select(x => new { x.Tarih, x.Durum, x.OkunduMu}).ToList();
            int yeni = 0, acik = 0, cevapsiz = 0;
            foreach (var item in tick)
            {
                TimeSpan tp = DateTime.Now - (DateTime)item.Tarih;
                if (tp.TotalMinutes < 60) yeni++;
                if (item.Durum == true) acik++;
                if (item.OkunduMu == false) cevapsiz++;
            }
            ViewBag.yeni = yeni;
            ViewBag.acik = acik;
            ViewBag.cevapsiz = cevapsiz;
            ViewBag.toplam = tick.Count;

            return View();
        }
        public ActionResult MyTickets()
        {
            string kul = Session["Kullanıcı"] as string;
            var mod = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kul);
            var ticks = edm.Tickets.Where(x => x.User_ID == mod.ID).OrderByDescending(k=>k.Tarih);
            return View(ticks);
        }
        public ActionResult NewTicket()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTicket(Ticket yeni)
        {
            HttpPostedFileBase file = Request.Files[0];
            string kadi = Session["Kullanıcı"] as string;
            User sahip = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kadi);
            if (file.ContentLength > 0)
            {
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-","");
                string uzanti = Path.GetExtension(file.FileName);
                string tamYol = "/Content/img/Ticket/" + DosyaAdi + uzanti;

                file.SaveAs(Server.MapPath(tamYol));
                yeni.ResimYol = tamYol;
            }
            try
            {
                Ticket tk = new Ticket();
                tk.OkunduMu = false;
                tk.Oncelik = yeni.Oncelik;
                tk.ResimYol = yeni.ResimYol;
                tk.User_ID = sahip.ID;
                tk.Durum = true;
                tk.Konu = yeni.Konu;
                tk.Icerik = yeni.Icerik;
                tk.Tarih = DateTime.Now;
                edm.Tickets.Add(tk);
                edm.SaveChanges();
                islem = "1";
                return Redirect(Request.RawUrl);
            }
            catch
            {
                islem = "0";
                return Redirect(Request.RawUrl);
            }
        }

        static string islem = null;
        public ActionResult ticketKontrol()
        {
            if (islem == "1")
                return Json(true, JsonRequestBehavior.AllowGet);
            else if (islem == "0")
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
                return Content("Bos");
        }
        public ActionResult viewTemizle()
        {
            islem = "Bos";
            return Content("true");
        }
        public JsonResult TicketDurumu(int id)
        {
            Ticket tk = edm.Tickets.SingleOrDefault(x => x.ID == id);
            if ((bool)tk.Durum)
            {
                tk.Durum = false;
                edm.SaveChanges();
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tk.Durum = true;
                edm.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TicketDetay(int id)
        {
            string kl = Session["Kullanıcı"] as string;
            ViewBag.kl = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kl).Ad_Soyad;
            ViewBag.tck = edm.Tickets.SingleOrDefault(x => x.ID == id);
            List<Yorum> yorums = edm.Yorums.Where(x => x.Ticket_ID == id).ToList();

            if (ViewBag.tck == null)
            {
                return Redirect(Request.RawUrl);
            }
            return View(yorums);
        }
        public JsonResult yorumYap(Yorum yrm)
        {
            try
            {
                string kl = Session["Kullanıcı"].ToString();
                User kul = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kl);
                Yorum yorum = new Yorum();
                yorum.Tarih = DateTime.Now;
                yorum.User_ID = kul.ID;
                yorum.Ticket_ID = yrm.Ticket_ID;
                yorum.Icerik_Yorum = yrm.Icerik_Yorum;
                edm.Yorums.Add(yorum);
                edm.SaveChanges();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        public ActionResult HesapAyarla()
        {
            string klSession = (string)Session["Kullanıcı"];
            User data = edm.Users.SingleOrDefault(x => x.KullaniciAdi == klSession);
            if (data != null)
            {
                UserViewModel mdel = data;
                return View(mdel);
            }
            else
                return RedirectToAction("Index","User");
        }

        [HttpPost]
        public JsonResult HesapAyarla(UserViewModel mdl)
        {
            JsonModel Jmodel = new JsonModel();
            try
            {
                string sr = Session["Kullanıcı"] as string;
                User usr = edm.Users.SingleOrDefault(x => x.KullaniciAdi == sr);
                usr.Ad_Soyad = mdl.Ad_Soyad;
                usr.KullaniciAdi = mdl.KullaniciAdi;
                usr.Sifre = mdl.Sifre;
                usr.Mail = mdl.Mail;
                edm.SaveChanges();

                Jmodel.IsSuccess = true;
                Jmodel.Mesaj = "Güncelleme işlemi başarılı";
            }
            catch (Exception ex)
            {
                Jmodel.IsSuccess = false;
                Jmodel.Mesaj = "Hata : " + ex.Message;
            }
            return Json(Jmodel, JsonRequestBehavior.AllowGet);
        }
    }
}
