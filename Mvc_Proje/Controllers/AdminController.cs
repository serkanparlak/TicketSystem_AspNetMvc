using Mvc_Proje.Models;
using Mvc_Proje.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje.Controllers
{
    public class AdminController : Login_AdminController
    {
        //
        // GET: /Admin/
        TicketSystemsContext edm = new TicketSystemsContext();
        public ActionResult Index()
        {
            var tick = edm.Tickets.Select(x => new { x.Tarih, x.Durum, x.OkunduMu }).ToList();
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

            string kl = Session["Admin"] as string;
            ViewBag.kl = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kl);

            return View();
        }
        public ActionResult Manage()
        {
            ViewBag.admin = Session["Admin"];
            var kullanicilar = edm.Users.Where(x => x.Rol == "Kullanıcı").ToList().OrderBy(x => x.KullaniciAdi);
            ViewBag.Adminler = edm.Users.Where(x => x.Rol == "Admin").ToList().OrderBy(x => x.ID);
            return View(kullanicilar);
        }
        [HttpPost]
        public JsonResult adminSil(int id)
        {
            JsonModel Jmodel = new JsonModel();
            try
            {
                var usr = edm.Users.SingleOrDefault(x => x.ID == id);
                usr.Rol = "Kullanıcı";
                edm.SaveChanges();
                Jmodel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Jmodel.IsSuccess = false;
                Jmodel.Mesaj = "Hata : " + ex.Message;
            }
            return Json(Jmodel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult yetkiVer(int id)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usr = edm.Users.SingleOrDefault(x => x.ID == id);
                if (usr != null)
                {
                    var tck = edm.Tickets.Where(x => x.User_ID == id).ToList();
                    if (tck.Count > 0 )
                    {
                        foreach (var item in tck)
                        {
                            edm.Tickets.Remove(item);
                            var yrm = edm.Yorums.Where(x => x.Ticket_ID == item.ID).ToList();
                            foreach (var item2 in yrm)
                            {
                                edm.Yorums.Remove(item2);
                            }
                            var dosya = edm.Tickets.SingleOrDefault(x => x.ResimYol == item.ResimYol);
                            if (dosya != null)
                            {
                                System.IO.File.Delete(Server.MapPath(dosya.ResimYol));
                            }
                        }
                    }
                    usr.Rol = "Admin";
                    edm.SaveChanges();
                    jmodel.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Mesaj = "Hata : " + ex.Message;
            }
            return Json(jmodel,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Tickets()
        {
            var tck = edm.Tickets.ToList().OrderByDescending(z => z.Durum).ThenBy(x => x.OkunduMu);
            return View(tck);
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
            string kl = Session["Admin"] as string;
            ViewBag.kl = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kl).Ad_Soyad;
            ViewBag.tck = edm.Tickets.SingleOrDefault(x => x.ID == id);
            var yorums = edm.Yorums.Where(x => x.Ticket_ID == id).ToList();

            if (ViewBag.tck == null)
            {
                return Redirect(Request.RawUrl);
            }
            return View(yorums);
        }
        [HttpPost]
        public JsonResult yorumYap(Yorum yrm)
        {
            try
            {
                Ticket cevap = edm.Tickets.SingleOrDefault(x => x.ID == yrm.Ticket_ID);
                cevap.OkunduMu = true;

                string kl = Session["Admin"] as string;
                User us = edm.Users.SingleOrDefault(x => x.KullaniciAdi == kl);
                Yorum nYrm = new Yorum();
                nYrm.Ticket_ID = yrm.Ticket_ID;
                nYrm.Tarih = DateTime.Now;
                nYrm.User_ID = us.ID;
                nYrm.Icerik_Yorum = yrm.Icerik_Yorum;
                edm.Yorums.Add(nYrm);
                edm.SaveChanges();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
            
        }
        public ActionResult UserManage()
        {
            return View(edm.Users.Where(x=>x.Rol=="Kullanıcı").ToList().OrderBy(y=>y.ID));
        }
        public ActionResult UserEdit(int id)
        {
            var usr = edm.Users.SingleOrDefault(x => x.ID == id);
            UserViewModel uvm = usr;
            return View(uvm);
        }
        [HttpPost]
        public JsonResult UserEdit(UserViewModel usrGelen)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usrGuncellenecek = edm.Users.SingleOrDefault(x => x.ID == usrGelen.ID);
                usrGuncellenecek.Ad_Soyad = usrGelen.Ad_Soyad;
                usrGuncellenecek.KullaniciAdi = usrGelen.KullaniciAdi;
                usrGuncellenecek.Sifre = usrGelen.Sifre;
                usrGuncellenecek.Mail = usrGelen.Mail;
                edm.SaveChanges();
                jmodel.IsSuccess = true;
                jmodel.Mesaj = "Admin";
            }
            catch(Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Mesaj = "Hata : "+ex.Message;
            }
            return Json(jmodel, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult userDelete(int id)
        {
            JsonModel jmodel = new JsonModel();
            try
            {
                User usr = edm.Users.SingleOrDefault(x => x.ID == id);
                if (usr != null)
                {
                    var tck = edm.Tickets.Where(x => x.User_ID == id).ToList();
                    if (tck.Count > 0)
                    {
                        foreach (var item in tck)
                        {
                            edm.Tickets.Remove(item);
                            var yrm = edm.Yorums.Where(x => x.Ticket_ID == item.ID).ToList();
                            foreach (var item2 in yrm)
                            {
                                edm.Yorums.Remove(item2);
                            }
                            var dosya = edm.Tickets.SingleOrDefault(x => x.ResimYol == item.ResimYol);
                            if (dosya != null)
                            {
                                System.IO.File.Delete(Server.MapPath(dosya.ResimYol));
                            }
                        }
                    }
                    edm.SaveChanges();
                    jmodel.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                jmodel.IsSuccess = false;
                jmodel.Mesaj = "Hata : " + ex.Message;
            }
            return Json(jmodel, JsonRequestBehavior.AllowGet);
        }

    }
}
