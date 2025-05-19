using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models.Bolumler;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public ActionResult Giris()
        {
            Session["Tab"] = "duyurular";

            return View();
        }

        [HttpPost]
        public ActionResult Giris(string username, string password)
        {

            // Veritabanında veya belirli bir yerde sakladığınız doğru kullanıcı adı ve şifreyi kontrol edin.
            // Bu örnekte hard-coded ("admin" ve "12345") kullanılıyor.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Eğer kullanıcı adı ya da şifre boşsa, hata mesajı göster
                ViewBag.ErrorMessage = "Kullanıcı adı ve şifre boş olamaz.";
                return View();
            }

            // Burada "admin" ve "12345" kullanıcı adı ve şifresi kontrol ediliyor.
            if (username == "admin" && password == "12345") // Doğru kullanıcı adı ve şifre
            {
                // Başarılıysa kullanıcıyı ana sayfaya yönlendir
                Session["UserRole"] = "Admin";
                return RedirectToAction("AnaSayfa", "Home");
            }
            else if (username == "berkay" && password == "12345")
            {
                Session["UserRole"] = "User";
                return RedirectToAction("AnaSayfa", "Home");
            }
            else
            {
                // Hatalı giriş durumunda hata mesajı göster
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }

        }

        public ActionResult AnaSayfa()
        {
            List<Duyurular> duyurular = db.Duyurular.OrderByDescending(a => a.Date).Take(5).ToList();
            return View(duyurular);
        }

        public ActionResult Bolumler()
        {
            Bolum bolum = new Bolum();
            bolum.CocukAcil = db.CocukAcil.ToList();
            bolum.CocukYogunBakim = db.CocukYogunBakim.ToList();
            bolum.CocukHematolojisiVeOnkolojisi = db.CocukHematolojisiVeOnkolojisi.ToList();

            return View(bolum);
        }

        public ActionResult Asistanlar()
        {

            List<Asistanlar> asistanlar = db.Asistanlar.ToList();

            return View(asistanlar);
        }

        public ActionResult OgretimUyeleri()
        {
            List<OgretimUyeleri> ogretimUyeleri = db.OgretimUyeleri.ToList();

            return View(ogretimUyeleri);
        }

        public ActionResult Nobetler()
        {
            return View();
        }

        public JsonResult GetNobetler()
        {
            var shifts = db.Nobetler.ToList().Select(s => new
            {
                title = $"{s.NobetBolumu} - {s.NobetciAsistan}",
                start = s.NobetTarihi.ToString("yyyy-MM-dd")
            });

            return Json(shifts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Randevular()
        {
            List<Randevular> randevular = db.Randevular.OrderByDescending(r => r.RandevuTarihi).ToList();
            return View(randevular);
        }

        public ActionResult Admin()
        {
            var viewModel = new AdminViewModel
            {
                Duyurular = db.Duyurular.ToList(),
                CocukAcil = db.CocukAcil.ToList(),
                CocukHematolojisiVeOnkolojisi = db.CocukHematolojisiVeOnkolojisi.ToList(),
                CocukYogunBakim = db.CocukYogunBakim.ToList(),
                Asistanlar = db.Asistanlar.ToList(),
                OgretimUyeleri = db.OgretimUyeleri.ToList(),
                Nobetler = db.Nobetler.ToList(),
                Randevular = db.Randevular.ToList()
            };
            return View(viewModel);
        }

        #region CRUD İşlemleri
        #region Duyurular
        [HttpPost]
        public ActionResult DuyuruEkle(Duyurular model)
        {
            if (ModelState.IsValid)
            {
                db.Duyurular.Add(model);
                db.SaveChanges();
            }
            Session["Tab"] = "duyurular";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult DuyuruGuncelle(Duyurular model)
        {
            //Console.WriteLine("Gelen ID: " + model.ID);
            
                Duyurular mevcutDuyuru = db.Duyurular.Find(model.ID);
                if (mevcutDuyuru != null)
                {
                    mevcutDuyuru.DuyuruMetni = model.DuyuruMetni;
                    mevcutDuyuru.Date = model.Date;
                    db.SaveChanges();
                }
            
            Session["Tab"] = "duyurular";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult DuyuruSil(int id)
        {
            Duyurular duyuru = db.Duyurular.Find(id);
            if (duyuru != null)
            {
                db.Duyurular.Remove(duyuru);
                db.SaveChanges();
            }
            Session["Tab"] = "duyurular";
            return RedirectToAction("Admin");
        }
        #endregion

        #region Bolumler
        [HttpPost]
        public ActionResult CocukAcilGuncelle(CocukAcil model)
        {
            using (var context = new DatabaseContext())
            {
                var mevcut = context.CocukAcil.Find(model.ID);
                if (mevcut != null)
                {

                    mevcut.OgretimUyesi = model.OgretimUyesi;
                    mevcut.NobetciAsistan = model.NobetciAsistan;
                    mevcut.YatakSayisi = model.YatakSayisi;
                    mevcut.BosYatakSayisi = model.BosYatakSayisi;
                    context.SaveChanges();
                }
            }
            Session["Tab"] = "bolumler";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult CocukHematolojisiVeOnkolojisiGuncelle(CocukHematolojisiVeOnkolojisi model)
        {
            using (var context = new DatabaseContext())
            {
                var mevcut = context.CocukHematolojisiVeOnkolojisi.Find(model.ID);
                if (mevcut != null)
                {

                    mevcut.OgretimUyesi = model.OgretimUyesi;
                    mevcut.NobetciAsistan = model.NobetciAsistan;
                    mevcut.YatakSayisi = model.YatakSayisi;
                    mevcut.BosYatakSayisi = model.BosYatakSayisi;
                    context.SaveChanges();
                }
            }
            Session["Tab"] = "bolumler";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult CocukYogunBakimGuncelle(CocukYogunBakim model)
        {
            using (var context = new DatabaseContext())
            {
                var mevcut = context.CocukYogunBakim.Find(model.ID);
                if (mevcut != null)
                {

                    mevcut.OgretimUyesi = model.OgretimUyesi;
                    mevcut.NobetciAsistan = model.NobetciAsistan;
                    mevcut.YatakSayisi = model.YatakSayisi;
                    mevcut.BosYatakSayisi = model.BosYatakSayisi;
                    context.SaveChanges();
                }
            }
            Session["Tab"] = "bolumler";
            return RedirectToAction("Admin");
        }

        #endregion

        #region Asistanlar
        [HttpPost]
        public ActionResult AsistanEkle(Asistanlar model)
        {
            if (ModelState.IsValid)
            {
                db.Asistanlar.Add(model);
                db.SaveChanges();
            }
            Session["Tab"] = "asistanlar";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult AsistanGuncelle(Asistanlar model)
        {
            using (var context = new DatabaseContext())
            {
                var asistan = context.Asistanlar.Find(model.ID);
                if (asistan != null)
                {
                    asistan.Ad = model.Ad;
                    asistan.Soyad = model.Soyad;
                    asistan.Mail = model.Mail;
                    asistan.Telefon = model.Telefon;
                    asistan.Adres = model.Adres;
                    context.SaveChanges();
                }
            }
            Session["Tab"] = "asistanlar";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult AsistanSil(int ID)
        {
            Asistanlar asistan = db.Asistanlar.Find(ID);
            if (asistan != null)
            {
                db.Asistanlar.Remove(asistan);
                db.SaveChanges();
            }
            Session["Tab"] = "asistanlar";
            return RedirectToAction("Admin");
        }
        #endregion

        #region Ogretim Uyeleri
        [HttpPost]
        public ActionResult OgretimUyesiEkle(OgretimUyeleri model)
        {
            if (ModelState.IsValid)
            {
                db.OgretimUyeleri.Add(model);
                db.SaveChanges();
            }
            Session["Tab"] = "ogretim";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult OgretimUyesiGuncelle(OgretimUyeleri model)
        {
            using (var context = new DatabaseContext())
            {
                var ogretim = context.OgretimUyeleri.Find(model.ID);
                if (ogretim != null)
                {   
                    ogretim.Ad = model.Ad;
                    ogretim.Soyad = model.Soyad;
                    ogretim.Mail = model.Mail;
                    ogretim.Telefon = model.Telefon;
                    ogretim.Adres = model.Adres;
                    context.SaveChanges();
                }
            }
            Session["Tab"] = "ogretim";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult OgretimUyesiSil(int ID)
        {
            OgretimUyeleri ogretim = db.OgretimUyeleri.Find(ID);
            if (ogretim != null)
            {
                db.OgretimUyeleri.Remove(ogretim);
                db.SaveChanges();
            }
            Session["Tab"] = "ogretim";
            return RedirectToAction("Admin");
        }
        #endregion

        #region Nobetler
        [HttpPost]
        public ActionResult NobetEkle(Nobetler model)
        {
            if (ModelState.IsValid)
            {
                db.Nobetler.Add(model);
                db.SaveChanges();
            }
            Session["Tab"] = "nobetler";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult NobetGuncelle(Nobetler model)
        {
            
                Nobetler nobetler = db.Nobetler.Find(model.ID);
                if (nobetler != null)
                {   
                    nobetler.NobetBolumu = model.NobetBolumu;
                    nobetler.NobetciAsistan = model.NobetciAsistan;
                    nobetler.NobetTarihi = model.NobetTarihi;
                    db.SaveChanges();
                }
            
            Session["Tab"] = "nobetler";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult NobetSil(int ID)
        {
            Nobetler nobetler = db.Nobetler.Find(ID);
            if (nobetler != null)
            {
                db.Nobetler.Remove(nobetler);
                db.SaveChanges();
            }
            Session["Tab"] = "nobetler";
            return RedirectToAction("Admin");
        }

        #endregion

        #region Randevular
        [HttpPost]
        public ActionResult RandevuEkle(Randevular model)
        {
            if (ModelState.IsValid)
            {
                db.Randevular.Add(model);
                db.SaveChanges();
            }
            Session["Tab"] = "randevular";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult RandevuGuncelle(Randevular model)
        {

            Randevular randevular = db.Randevular.Find(model.ID);
            if (randevular != null)
            {
                randevular.RandevuOgretimUyesi = model.RandevuOgretimUyesi;
                randevular.RandevuAsistan = model.RandevuAsistan;
                randevular.RandevuTarihi = model.RandevuTarihi;
                db.SaveChanges();
            }

            Session["Tab"] = "randevular";
            return RedirectToAction("Admin");
        }

        [HttpPost]
        public ActionResult RandevuSil(int ID)
        {
            Randevular randevular = db.Randevular.Find(ID);
            if (randevular != null)
            {
                db.Randevular.Remove(randevular);
                db.SaveChanges();
            }
            Session["Tab"] = "randevular";
            return RedirectToAction("Admin");
        }
        #endregion
        #endregion
    }
}