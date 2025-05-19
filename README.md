# Pediatri Asistan Nöbet Takip Sistemi

## 🎬 Tanıtım Videosu
[![Tanıtım Videosu](https://img.youtube.com/vi/aCJ_rFHl12E/0.jpg)](https://www.youtube.com/watch?v=aCJ_rFHl12E)

## 🔧 Kullanılan Teknolojiler

- ASP.NET MVC (.NET Framework)
- Entity Framework (Code First)
- SQL Server (Database)
- HTML, CSS, Bootstrap (Frontend)
- JavaScript

## 📌 Temel Özellikler

- **Admin Paneli:**
  - Asistan, öğretim üyesi ve bölüm bilgilerini yönetme
  - Nöbet çizelgelerini oluşturma ve güncelleme
  - Randevu saatlerini tanımlama
  - Acil durum haberlerini paylaşma

- **Kullanıcı Paneli:**
  - Asistanların hangi gün ve bölümde nöbetçi olduğunu takvim üzerinden görme
  - Öğretim üyelerinin bilgilerine ulaşma
  - Randevu alma, düzenleme ve silme işlemleri
  - Bölüm tanıtımlarını ve güncel hasta/yatak bilgilerini görüntüleme
  - Acil durum bildirimlerini takip etme

## 📁 Veritabanı Tabloları (Örnek)

1. `Assistant` - Asistan bilgileri
2. `Doctor` - Öğretim üyesi bilgileri
3. `Department` - Bölüm bilgileri
4. `Shift` - Nöbet çizelgesi
5. `Appointment` - Randevu kayıtları
6. `EmergencyAnnouncement` - Acil durum duyuruları
7. `User` - Giriş yapan kullanıcılar (admin ve kullanıcı ayrımı)
8. `AvailabilitySlot` - Öğretim üyesi müsaitlik zamanları

## 🔐 Yetkilendirme

- Admin paneli sadece yetkili kullanıcılar tarafından erişilebilir durumdadır.
- Kullanıcı paneli herkesin erişimine açık olup yalnızca düzenleme işlemleri giriş yapmış kullanıcılar tarafından yapılabilir.

---

**Not:** Bu proje bireysel olarak gerçekleştirilmiştir ve tüm veritabanı yapısı Code First yaklaşımı ile oluşturulmuştur.




