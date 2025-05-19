using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using WebProject.Models.Bolumler;

namespace WebProject.Models
{
    public class VeriTabaniOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.DuyuruMetni = "duyuru metni1";
            duyurular.Date = DateTime.Now;
            context.Duyurular.Add(duyurular);

            
            CocukAcil cocukAcil = new CocukAcil();
            cocukAcil.OgretimUyesi = "öğretim üyesi1";
            cocukAcil.NobetciAsistan = "nöbetçi1";
            cocukAcil.YatakSayisi = 10;
            cocukAcil.BosYatakSayisi = 3;
            context.CocukAcil.Add(cocukAcil);

            CocukHematolojisiVeOnkolojisi cocukHematolojisiVeOnkolojisi= new CocukHematolojisiVeOnkolojisi();
            cocukHematolojisiVeOnkolojisi.OgretimUyesi = "öğretim üyesi2";
            cocukHematolojisiVeOnkolojisi.NobetciAsistan = "nöbetçi2";
            cocukHematolojisiVeOnkolojisi.YatakSayisi = 10;
            cocukHematolojisiVeOnkolojisi.BosYatakSayisi = 2;
            context.CocukHematolojisiVeOnkolojisi.Add(cocukHematolojisiVeOnkolojisi);

            CocukYogunBakim cocukYogunBakim= new CocukYogunBakim();
            cocukYogunBakim.OgretimUyesi = "öğretim üyesi3";
            cocukYogunBakim.NobetciAsistan = "nöbetçi3";
            cocukYogunBakim.YatakSayisi = 10;
            cocukYogunBakim.BosYatakSayisi = 1;
            context.CocukYogunBakim.Add(cocukYogunBakim);

            Asistanlar asistanlar = new Asistanlar();
            asistanlar.Ad = "asistan ad1";
            asistanlar.Soyad = "asistan soyad1";
            asistanlar.Mail = "asistan mail1";
            asistanlar.Telefon = "asistan tel1";
            asistanlar.Adres = "asistan adres1";
            context.Asistanlar.Add(asistanlar);

            OgretimUyeleri ogretimUyeleri= new OgretimUyeleri();
            ogretimUyeleri.Ad = "öğretim üyesi ad1";
            ogretimUyeleri.Soyad = "öğretim üyesi soyad1";
            ogretimUyeleri.Mail = "öğretim üyesi mail1";
            ogretimUyeleri.Telefon = "öğretim üyesi tel1";
            ogretimUyeleri.Adres = "öğretim üyesi adres1";
            context.OgretimUyeleri.Add(ogretimUyeleri);

            Nobetler nobetler = new Nobetler();
            nobetler.NobetciAsistan = "asistan1";
            nobetler.NobetBolumu = "Çocuk Acil";
            nobetler.NobetTarihi = DateTime.Now;
            context.Nobetler.Add(nobetler);

            Randevular randevular = new Randevular();
            randevular.RandevuAsistan = "asistan1";
            randevular.RandevuOgretimUyesi = "öğretim üyesi1";
            randevular.RandevuTarihi = DateTime.Now;
            context.Randevular.Add(randevular);

            context.SaveChanges();
        }
    }
}