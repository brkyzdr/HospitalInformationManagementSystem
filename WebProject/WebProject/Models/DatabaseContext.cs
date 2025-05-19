using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebProject.Models.Bolumler;

namespace WebProject.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Asistanlar> Asistanlar { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<CocukAcil> CocukAcil { get; set; }
        public DbSet<CocukHematolojisiVeOnkolojisi> CocukHematolojisiVeOnkolojisi { get; set; }
        public DbSet<CocukYogunBakim> CocukYogunBakim { get; set; }
        public DbSet<Nobetler> Nobetler { get; set; }
        public DbSet<OgretimUyeleri> OgretimUyeleri { get; set; }
        public DbSet<Randevular> Randevular { get; set; }


        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTabaniOlusturucu());
        }
    }
}