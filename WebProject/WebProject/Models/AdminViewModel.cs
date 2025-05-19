using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models.Bolumler;

namespace WebProject.Models
{
    public class AdminViewModel
    {        
        public List<Duyurular> Duyurular { get; set; }
        public List<CocukAcil> CocukAcil { get; set; }
        public List<CocukHematolojisiVeOnkolojisi> CocukHematolojisiVeOnkolojisi { get; set; }
        public List<CocukYogunBakim> CocukYogunBakim { get; set; }
        public List<Asistanlar> Asistanlar { get; set; }
        public List<OgretimUyeleri> OgretimUyeleri { get; set; }
        public List<Nobetler> Nobetler { get; set; }
        public List<Randevular> Randevular { get; set; }
    }
}